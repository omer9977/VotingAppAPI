using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Persistence.Enums;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly IFileService _fileService;
        //private readonly IFileReadRepo _fileReadRepo;
        //private readonly IFileWriteRepo _fileWriteRepo;
        private readonly ICriminalRecordFileReadRepo _criminalRecordFileReadRepo;
        private readonly ICriminalRecordFileWriteRepo _criminalRecordFileWriteRepo;
        private readonly ITranscriptFileReadRepo _transcriptFileReadRepo;
        private readonly ITranscriptFileWriteRepo _transcriptFileWriteRepo;
        private readonly ICandidateReadRepo _candidateReadRepo;
        private readonly ICandidateWriteRepo _candidateWriteRepo;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IStudentWriteRepo _studentWriteRepo;
        private readonly IStorageService _storageService;


        public TestController(IWebHostEnvironment webHostEnvironment/*, IFileService fileService*/,
            //IFileReadRepo fileReadRepo, IFileWriteRepo fileWriteRepo,
            ICriminalRecordFileReadRepo criminalRecordFileReadRepo,
            ICriminalRecordFileWriteRepo criminalRecordFileWriteRepo,
            ITranscriptFileReadRepo transcriptFileReadRepo,
            ITranscriptFileWriteRepo transcriptFileWriteRepo,
            ICandidateWriteRepo candidateWriteRepo,
            ICandidateReadRepo candidateReadRepo, IStudentReadRepo studentReadRepo, 
            IStudentWriteRepo studentWriteRepo,
            IStorageService storageService)
        {
            _webHostEnvironment = webHostEnvironment;
            //_fileService = fileService;
            //_fileReadRepo = fileReadRepo;
            //_fileWriteRepo = fileWriteRepo;
            _criminalRecordFileReadRepo = criminalRecordFileReadRepo;
            _criminalRecordFileWriteRepo = criminalRecordFileWriteRepo;
            _transcriptFileReadRepo = transcriptFileReadRepo;
            _transcriptFileWriteRepo = transcriptFileWriteRepo;
            _candidateWriteRepo = candidateWriteRepo;
            _candidateReadRepo = candidateReadRepo;
            _studentReadRepo = studentReadRepo;
            _studentWriteRepo = studentWriteRepo;
            _storageService = storageService;
        }
        [Route("AddRange")]
        [HttpPost]
        public async Task AddRange()
        {
            //await _studentWriteRepo.AddRangeAsync(new() {
            //new(){StudentNumber = 270,Name="ömer" },
            ////new(){StudentNumber = 250,Name="asdf" },
            ////new(){StudentNumber = 260,Name="wefe" },


            //});
            //await _studentWriteRepo.SaveChangesAsync();
            //await _studentWriteRepo.AddRangeAsync(new() {
            //new(){StudentNumber = 270,Name="ömer" },
            //new(){StudentNumber = 250,Name="asdf" },
            //new(){StudentNumber = 260,Name="wefe" },


            //});
            //await _studentWriteRepo.SaveChangesAsync();

            var student = await _studentReadRepo.GetByIdAsync(1);

            await _candidateWriteRepo.AddAsync(new() { Student = student, ApproveStatus = 0, ApplicationDate = DateOnly.MaxValue });
            await _candidateWriteRepo.SaveChangesAsync();
            var ca = await _candidateReadRepo.GetByIdAsync(1);
        }

        [Route("UploadCandidateImage")]
        [HttpPost]
        public async Task<IActionResult> UploadCandidateImage(int candidateId)
        {
            var datas = await _storageService.UploadAsync("resorce\\candidates\\profilePhotos", Request.Form.Files);
            var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
            await _transcriptFileWriteRepo.AddRangeAsync(datas.Select(d => new TranscriptFile()
            {
                FileName = d.fileName,
                Path = d.path,
                Candidate = candidate,
                ApprovedStatus = (short)ApproveEnum.OnHold
            }).ToList());
            await _transcriptFileWriteRepo.SaveChangesAsync();
            return Ok();
        }
    }
}
