using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Request.File;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
using VotingAPI.ObsService.Interfaces;
//using VotingAPI.Domain.Entities.Identity;
//using VotingAPI.Domain.Entities.FileTypes;
using VotingAPI.Persistence.Enums;
using C = VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Persistence.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateReadRepo _candidateReadRepo;
        private readonly ICandidateWriteRepo _candidateWriteRepo;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IStorageService _storageService;
        private readonly IUserService _userService;
        private readonly IElectionService _electionService;
        private readonly IElectionReadRepo _electionReadRepo;
        private readonly IObsStudentService _obsStudentService;

        //private readonly IProfilePhotoFileWriteRepo _profilePhotoFileWriteRepo;
        //private readonly IProfilePhotoFileReadRepo _profilePhotoFileReadRepo;
        //private readonly IFileReadRepo _fileReadRepo;
        //private readonly IFileWriteRepo _fileWriteRepo;
        private readonly IConfiguration _configuration;
        private readonly IUserWriteRepo _userWriteRepo;
        private readonly IUserReadRepo _userReadRepo;
        //private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CandidateService(ICandidateReadRepo candidateReadRepo,
            ICandidateWriteRepo candidateWriteRepo,
            IStudentReadRepo studentReadRepo,
            IElectionReadRepo electionReadRepo,
            IStorageService storageService,
            //IProfilePhotoFileWriteRepo profilePhotoFileWriteRepo,
            //IProfilePhotoFileReadRepo profilePhotoFileReadRepo,
            IConfiguration configuration,
            IMapper mapper,
            IUserService userService,
            IElectionService electionService,
            //IFileReadRepo fileReadRepo,
            //IFileWriteRepo fileWriteRepo,
            //UserManager<AppUser> userManager
            IUserWriteRepo userWriteRepo,
            IUserReadRepo userReadRepo,
            IObsStudentService obsStudentService
            )
        {
            _candidateReadRepo = candidateReadRepo;
            _candidateWriteRepo = candidateWriteRepo;
            _studentReadRepo = studentReadRepo;
            _storageService = storageService;
            //_profilePhotoFileWriteRepo = profilePhotoFileWriteRepo;
            //_profilePhotoFileReadRepo = profilePhotoFileReadRepo;
            _configuration = configuration;
            _mapper = mapper;
            _userService = userService;
            _electionService = electionService;
            _electionReadRepo = electionReadRepo;
            _userWriteRepo = userWriteRepo;
            _userReadRepo = userReadRepo;
            _obsStudentService = obsStudentService;
            //_fileReadRepo = fileReadRepo;
            //_fileWriteRepo = fileWriteRepo;
            //_userManager = userManager;
        }

        public async Task<bool> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var user = await _userReadRepo.GetSingleAsync(x => x.UserName == addCandidateRequest.UserName);
            var eDevletStatus = _obsStudentService.FindUserByUserName(addCandidateRequest.UserName).EdevletStatus;
            var student = await _studentReadRepo.Table.FirstOrDefaultAsync(x => x.UserId == user.Id);
            var election = await _electionReadRepo.Table.FirstOrDefaultAsync(
            x => x.DepartmentId == student.DepartmentId
            && DateTime.UtcNow > x.StartDate
            && DateTime.UtcNow < x.EndDate);

            user.UserRole = UserRole.Candidate;
            _userWriteRepo.Update(user);
            await _userWriteRepo.SaveChangesAsync();
            bool candidateAdded = await _candidateWriteRepo.AddAsync(new()
            {
                UserId = user.Id,
                ElectionId = election.Id,
                Description = addCandidateRequest.Description,
                ApproveStatus = eDevletStatus ? ApproveStatus.Approved : ApproveStatus.Rejected
            });
            if (!candidateAdded)
                throw new DataNotAddedException();

            return await _candidateWriteRepo.SaveChangesAsync() > 0;
        }

        public Task<bool> DeleteCandidateProfilePhotoAsync(int candidateId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetCandidateResponse> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateReadRepo.GetByIdAsync(id);
            if (candidate == null)
                throw new DataNotFoundException(id);
            var candidateResponse = _mapper.Map<GetCandidateResponse>(candidate);
            return candidateResponse;
        }

        public List<GetCandidateResponse> GetCandidateList()
        {
            var candidates = _candidateReadRepo.Table/*.Include(x => x.Student.Department).Include(x => x.Student.User)*/.AsNoTracking().ToList();
            //var candidates = _candidateReadRepo.GetByIdAsync();
            var candidateList = _mapper.Map<List<GetCandidateResponse>>(candidates);
            return candidateList;
        }

        //todo Student objesi null geliyor
        //public async Task<GetFileResponse> GetCandidateFileAsync(int candidateId, short fileTypeId)
        //{
        //    var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
        //    //var photoDb = await _fileReadRepo.GetSingleAsync(p => p.UserId == candidate.Student.UserId);
        //    //if (photoDb == null)
        //    //    throw new DataNotFoundException(candidateId);

        //    //string fullPath = $"{_configuration["BaseStorageUrl"]}/{photoDb.Path}";
        //    //GetFileResponse response = new() { UserId = candidate.Student.UserId, FileName = photoDb.FileName, Path = fullPath };//todo buraları kontrol et çok kötü kod
        //    return candidate/*response*/;
        //}
        //public async Task<bool> UploadCandidateFileAsync(AddCandidateFileRequest addFileRequest)
        //{
        //    var candidate = await _candidateReadRepo.GetByIdAsync(addFileRequest.CandidateId);
        //    var user = await _userManager.FindByIdAsync(candidate.Student.UserId.ToString());
        //    var datas = await _storageService.UploadAsync(addFileRequest.FileTypeId.ToString().ToLower(), addFileRequest.Files);
        //    if (datas == null)
        //        throw new DataNotFoundException("Files could not found!");
        //    //var user = await _userManager.FindByIdAsync(addFileRequest.UserId.ToString());
        //    if (user == null)
        //        throw new DataNotFoundException(user.Id);
        //    await _fileWriteRepo.AddRangeAsync(datas.Select(d => new C.File() //todo burada mapper kullan
        //    {
        //        FileName = d.fileName,
        //        Path = d.path,
        //        User = user,
        //        Storage = _storageService.StorageName,
        //        ApprovedStatus = (short)ApproveEnum.OnHold,
        //        FileTypeId = (short)addFileRequest.FileTypeId,
        //        UserId = user.Id
        //    }).ToList());
        //    await _fileWriteRepo.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<bool> DeleteCandidateFileAsync(int candidateId, short fileTypeId)
        //{
        //    var candidate = await _candidateReadRepo.GetByIdAsync(candidateId);
        //    var student = await _studentReadRepo.GetByIdAsync(candidate.StudentId);//todo burası çok kötü olmuş, çok fazla db ye istek gidiyor
        //    var file = await _fileReadRepo.GetSingleAsync(c => c.UserId == student.UserId && c.FileTypeId == fileTypeId);
        //    if (file == null)
        //        throw new DataNotFoundException(candidateId);
        //    _fileWriteRepo.Remove(file);
        //    await _fileWriteRepo.SaveChangesAsync();
        //    await _storageService.DeleteFileAsync(file.Path, file.FileName);
        //    return true;
        //}//todo burada null kontrolleri çok oldu, kısa yöntemi yok mu
    }
}
