using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
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

        public async Task<AddCandidateResponse> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var student = await _studentReadRepo.GetSingleAsync(c => c.StudentNumber == addCandidateRequest.StudentNumber);
            var candidate = await _candidateWriteRepo.AddAsync(new() { Student= student, ApplicationDate = DateOnly.FromDateTime(DateTime.Now),ApproveStatus=0});

            //todo exception yap
            var candidateResponse = _mapper.Map<AddCandidateResponse>(candidate);
            return candidateResponse;
        }

        public async Task<GetCandidateResponse> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateReadRepo.Table.Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);

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
        public async Task<GetProfilePhotoResponse> GetCandidateImage(int candidateId)
        {
            var photoDb = await _profilePhotoFileReadRepo.GetSingleAsync(p => p.CandidateId == candidateId);
            string fullPath = $"{_configuration["BaseStorageUrl"]}/{photoDb.Path}";
            GetProfilePhotoResponse response = new() { CandidateId = candidateId, FileName = photoDb.FileName, Path = fullPath };
            return response;
        }
        public async Task<AddProfilePhotoResponse> UploadCandidateImageAsync(int candidateId, IFormFileCollection files)
        {
            var datas = await _storageService.UploadAsync("profilephotos", files);
            var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
            await _profilePhotoFileWriteRepo.AddRangeAsync(datas.Select(d => new ProfilePhotoFile()
            {
                FileName = d.fileName,
                Path = d.path,
                Candidate = candidate,
                Storage = _storageService.StorageName,
                ApprovedStatus = (short)ApproveEnum.OnHold
            }).ToList());
            await _profilePhotoFileWriteRepo.SaveChangesAsync();
            var photoDb = await _profilePhotoFileReadRepo.GetSingleAsync(p => p.CandidateId == candidateId);
            var photoResponse = _mapper.Map<AddProfilePhotoResponse>(photoDb);
            return photoResponse;
        }
    }
}
