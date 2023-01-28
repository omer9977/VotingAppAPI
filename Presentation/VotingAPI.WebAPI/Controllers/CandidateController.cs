using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities.FileTypes;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/Candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICriminalRecordFileReadRepo _criminalRecordFileReadRepo;
        private readonly ICriminalRecordFileWriteRepo _criminalRecordFileWriteRepo;
        private readonly ITranscriptFileReadRepo _transcriptFileReadRepo;
        private readonly ITranscriptFileWriteRepo _transcriptFileWriteRepo;
        private readonly ICandidateReadRepo _candidateReadRepo;
        private readonly ICandidateWriteRepo _candidateWriteRepo;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IStorageService _storageService;
        private readonly IProfilePhotoFileWriteRepo _profilePhotoFileWriteRepo;
        private readonly IProfilePhotoFileReadRepo _profilePhotoFileReadRepo;
        private readonly IConfiguration _configuration;
        private readonly ICandidateService _candidateService;



        public CandidateController(IWebHostEnvironment webHostEnvironment,
            //IFileReadRepo fileReadRepo, IFileWriteRepo fileWriteRepo,
            ICriminalRecordFileReadRepo criminalRecordFileReadRepo,
            ICriminalRecordFileWriteRepo criminalRecordFileWriteRepo,
            ITranscriptFileReadRepo transcriptFileReadRepo,
            ITranscriptFileWriteRepo transcriptFileWriteRepo,
            ICandidateWriteRepo candidateWriteRepo,
            ICandidateReadRepo candidateReadRepo, IStudentReadRepo studentReadRepo, IStorageService storageService,
            IProfilePhotoFileReadRepo profilePhotoFileReadRepo, IProfilePhotoFileWriteRepo profilePhotoFileWriteRepo, IConfiguration configuration, ICandidateService candidateService)
        {
            _webHostEnvironment = webHostEnvironment;
            //_fileReadRepo = fileReadRepo;
            //_fileWriteRepo = fileWriteRepo;
            _criminalRecordFileReadRepo = criminalRecordFileReadRepo;
            _criminalRecordFileWriteRepo = criminalRecordFileWriteRepo;
            _transcriptFileReadRepo = transcriptFileReadRepo;
            _transcriptFileWriteRepo = transcriptFileWriteRepo;
            _candidateWriteRepo = candidateWriteRepo;
            _candidateReadRepo = candidateReadRepo;
            _studentReadRepo = studentReadRepo;
            _storageService = storageService;
            _profilePhotoFileReadRepo = profilePhotoFileReadRepo;
            _profilePhotoFileWriteRepo = profilePhotoFileWriteRepo;
            _configuration = configuration;
            _candidateService = candidateService;
        }
        [Route("AddCandidate")]
        [HttpPost]
        public async Task<IActionResult> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var response = _candidateService.AddCandidateAsync(addCandidateRequest);
            return Ok(response);
        }

        [Route("GetCandidateImage")]
        [HttpPost]
        public async Task<IActionResult> GetCandidateImageAsync(int candidateId)
        {
            //var photo = await _transcriptFileReadRepo.GetByIdAsync(candidateId);

            //var candidate = await _storageService.GetFiles(photo.Path);
            //var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
            //await _transcriptFileWriteRepo.AddRangeAsync(datas.Select(d => new TranscriptFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //    Candidate = candidate,
            //    Storage = _storageService.StorageName,
            //    ApprovedStatus = (short)ApproveEnum.OnHold
            //}).ToList());
            //await _transcriptFileWriteRepo.SaveChangesAsync();
            var photoDb = await _profilePhotoFileReadRepo.GetSingleAsync(p => p.CandidateId == candidateId);
            string asdf = $"{_configuration["BaseStorageUrlAzure"]}/{photoDb.Path}";
            return Ok();
        }
        [Route("UploadCandidateImage")]
        [HttpPost]
        public async Task<IActionResult> UploadCandidateImageAsync(int candidateId)
        {
            var photoResponse =  await _candidateService.UploadCandidateImageAsync(candidateId, Request.Form.Files);
            return Ok(photoResponse);
        }
        [Route("DeleteCandidateProfilePhoto")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCandidateProfilePhotoAsync(int candidateId)
        {
            var profilePhoto = await _profilePhotoFileReadRepo.GetSingleAsync(c => c.CandidateId == candidateId);
            _profilePhotoFileWriteRepo.Remove(profilePhoto);
            _profilePhotoFileWriteRepo.SaveChangesAsync();
            //string fullPath = $"{configuration["BaseStorageUrlAzure"]}/{profilePhoto.Path}";
            await _storageService.DeleteFileAsync(profilePhoto.Path, profilePhoto.FileName);
            return Ok();
        }
    }
}
