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

        [Route("GetAllCandidates")]
        [HttpGet]
        public IActionResult GetCandidateList()
        {
            var response = _candidateService.GetCandidateList();
            if (Result.issuccefful = false)
            {
                return BadRequest();//400
            }
        }

        [Route("GetCandidateById")]
        [HttpGet]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var response = await _candidateService.GetCandidateByIdAsync(id);
            return Ok(response);
        }

        [Route("AddCandidate")]
        [HttpPost]
        public async Task<IActionResult> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var response = _candidateService.AddCandidateAsync(addCandidateRequest);
            return Ok(response);
        }

        [Route("GetCandidateImage")]
        [HttpGet]
        public async Task<IActionResult> GetCandidateImageAsync(int candidateId)
        {
            var candidateImage = await _candidateService.GetCandidateImage(candidateId);
            return Ok(candidateImage);
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
