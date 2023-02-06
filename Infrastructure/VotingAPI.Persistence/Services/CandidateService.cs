using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Persistence.Enums;

namespace VotingAPI.Persistence.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateReadRepo _candidateReadRepo;
        private readonly ICandidateWriteRepo _candidateWriteRepo;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IStorageService _storageService;
        private readonly IProfilePhotoFileWriteRepo _profilePhotoFileWriteRepo;
        private readonly IProfilePhotoFileReadRepo _profilePhotoFileReadRepo;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CandidateService(ICandidateReadRepo candidateReadRepo,
            ICandidateWriteRepo candidateWriteRepo,
            IStudentReadRepo studentReadRepo,
            IStorageService storageService,
            IProfilePhotoFileWriteRepo profilePhotoFileWriteRepo,
            IProfilePhotoFileReadRepo profilePhotoFileReadRepo,
            IConfiguration configuration,
            IMapper mapper
            )
        {
            _candidateReadRepo = candidateReadRepo;
            _candidateWriteRepo = candidateWriteRepo;
            _studentReadRepo = studentReadRepo;
            _storageService = storageService;
            _profilePhotoFileWriteRepo = profilePhotoFileWriteRepo;
            _profilePhotoFileReadRepo = profilePhotoFileReadRepo;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<bool> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var student = await _studentReadRepo.GetSingleAsync(c => c.StudentNumber == addCandidateRequest.StudentNumber);
            if (student == null)
                throw new DataNotFoundException(addCandidateRequest.StudentNumber);
            bool candidateAdded = await _candidateWriteRepo.AddAsync(new() { Student = student, ApplicationDate = DateOnly.FromDateTime(DateTime.Now), ApproveStatus = 0 });
            if (!candidateAdded)
                throw new DataNotAddedException();
            await _candidateWriteRepo.SaveChangesAsync();
            return true;
        }

        public async Task<GetCandidateResponse> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateReadRepo.Table.Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
            if (candidate == null)
                throw new DataNotFoundException(id);
            //todo exception yap
            var candidateResponse = _mapper.Map<GetCandidateResponse>(candidate);
            return candidateResponse;
        }

        public List<GetCandidateResponse> GetCandidateList()
        {
            var candidates = _candidateReadRepo.Table.Include(x => x.Student).ToList();
            var candidateList = _mapper.Map<List<GetCandidateResponse>>(candidates);
            return candidateList;
        }
        //todo Student objesi null geliyor
        public async Task<GetProfilePhotoResponse> GetCandidateImageAsync(int candidateId)
        {
            var photoDb = await _profilePhotoFileReadRepo.GetSingleAsync(p => p.CandidateId == candidateId);
            if (photoDb == null)
                throw new DataNotFoundException(candidateId);

            string fullPath = $"{_configuration["BaseStorageUrl"]}/{photoDb.Path}";
            GetProfilePhotoResponse response = new() { CandidateId = candidateId, FileName = photoDb.FileName, Path = fullPath };
            return response;
        }
        public async Task<bool> UploadCandidateImageAsync(int candidateId, IFormFileCollection files)
        {
            var datas = await _storageService.UploadAsync("profilephotos", files);
            if (datas == null)
                throw new DataNotFoundException("Files could not found!");
            var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
            if (candidate == null)
                throw new DataNotFoundException(candidateId);
            await _profilePhotoFileWriteRepo.AddRangeAsync(datas.Select(d => new ProfilePhotoFile()
            {
                FileName = d.fileName,
                Path = d.path,
                Candidate = candidate,
                Storage = _storageService.StorageName,
                ApprovedStatus = (short)ApproveEnum.OnHold
            }).ToList());
            await _profilePhotoFileWriteRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCandidateProfilePhotoAsync(int candidateId)
        {
            var profilePhoto = await _profilePhotoFileReadRepo.GetSingleAsync(c => c.CandidateId == candidateId);
            if (profilePhoto == null)
                throw new DataNotFoundException(candidateId);
            _profilePhotoFileWriteRepo.Remove(profilePhoto);
            _profilePhotoFileWriteRepo.SaveChangesAsync();
            await _storageService.DeleteFileAsync(profilePhoto.Path, profilePhoto.FileName);
            return true;
        }//todo burada null kontrolleri çok oldu, kısa yöntemi yok mu
    }
}
