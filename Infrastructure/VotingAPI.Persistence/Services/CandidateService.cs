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
using VotingAPI.Application.Dto.Response;
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

        public async Task<Result> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var student = await _studentReadRepo.GetSingleAsync(c => c.StudentNumber == addCandidateRequest.StudentNumber);
            if (student == null)
                return new Result()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.PropertyNotFound(nameof(addCandidateRequest.StudentNumber))
                };
            bool candidateAdded = await _candidateWriteRepo.AddAsync(new() { Student= student, ApplicationDate = DateOnly.FromDateTime(DateTime.Now),ApproveStatus=0});
            await _candidateWriteRepo.SaveChangesAsync();
            if (!candidateAdded)
                return new Result()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.NotAddedRecord
                };
            else
                return new Result()
                {
                    IsSuccessful = true,
                    Message = ResultMessages.AddedRecord
                };
        }

        public async Task<Result> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateReadRepo.Table.Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
            if (candidate == null)
                return new Result()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.NotFoundRecord
                };
            var candidateResponse = _mapper.Map<GetCandidateResponse>(candidate);
            return new ResultData<GetCandidateResponse>()
            {
                Data = candidateResponse,
                IsSuccessful = true,
                Message = ResultMessages.FoundRecord
            };
        }

        public Result GetCandidateList()
        {
            var candidates = _candidateReadRepo.Table.Include(x => x.Student).ToList();
            var candidateList = _mapper.Map<List<GetCandidateResponse>>(candidates);
            return new ResultData<List<GetCandidateResponse>>()
            {
                Data = candidateList,
                IsSuccessful = true,
            };
        }
        //todo Student objesi null geliyor
        public async Task<Result> GetCandidateImage(int candidateId)
        {
            var photoDb = await _profilePhotoFileReadRepo.GetSingleAsync(p => p.CandidateId == candidateId);
            if (photoDb == null)
                return new()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.NotFoundRecord
                };
            string fullPath = $"{_configuration["BaseStorageUrl"]}/{photoDb.Path}";
            GetProfilePhotoResponse response = new() { CandidateId = candidateId, FileName = photoDb.FileName, Path = fullPath };
            return new ResultData<GetProfilePhotoResponse>()
            {
                Data = response,
                IsSuccessful = true,
                Message = ResultMessages.FoundRecord
            };
        }
        public async Task<Result> UploadCandidateImageAsync(int candidateId, IFormFileCollection files)
        {
            var datas = await _storageService.UploadAsync("profilephotos", files);
            if (datas == null)
                return new()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.NotAddedRecord
                };
            var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
            if (candidate == null)
                return new()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.NotFoundRecord
                };
            await _profilePhotoFileWriteRepo.AddRangeAsync(datas.Select(d => new ProfilePhotoFile()
            {
                FileName = d.fileName,
                Path = d.path,
                Candidate = candidate,
                Storage = _storageService.StorageName,
                ApprovedStatus = (short)ApproveEnum.OnHold
            }).ToList());
            await _profilePhotoFileWriteRepo.SaveChangesAsync();
            return new() 
            {
                IsSuccessful = true,
                Message = ResultMessages.AddedRecord
            };
        }

        public async Task<Result> DeleteCandidateProfilePhotoAsync(int candidateId)
        {
            var profilePhoto = await _profilePhotoFileReadRepo.GetSingleAsync(c => c.CandidateId == candidateId);
            if (profilePhoto == null)
                return new()
                {
                    IsSuccessful = false,
                    Message = ResultMessages.NotFoundRecord
                };
            _profilePhotoFileWriteRepo.Remove(profilePhoto);
            _profilePhotoFileWriteRepo.SaveChangesAsync();
            await _storageService.DeleteFileAsync(profilePhoto.Path, profilePhoto.FileName);
            return new()
            {
                IsSuccessful = true,
                Message = ResultMessages.DeleteRecord
            };
        }//todo burada null kontrolleri çok oldu, kısa yöntemi yok mu
    }
}
