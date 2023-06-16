using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Storage;
using VotingAPI.Application.Abstractions.Token;
using VotingAPI.Application.Dto.General;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Request.File;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Enums;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Extensions.Mapping;
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
        private readonly ITokenService _tokenService;

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
            IObsStudentService obsStudentService,
            ITokenService tokenService
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
            _tokenService = tokenService;
            //_fileReadRepo = fileReadRepo;
            //_fileWriteRepo = fileWriteRepo;
            //_userManager = userManager;
        }

        public async Task<TokenResponse> AddCandidateAsync(AddCandidateRequest addCandidateRequest)
        {
            var user = await _userReadRepo.GetSingleAsync(x => x.UserName == addCandidateRequest.UserName);
            var eDevletStatus = _obsStudentService.FindUserByUserName(addCandidateRequest.UserName).EdevletStatus;
            var student = await _studentReadRepo.Table.FirstOrDefaultAsync(x => x.UserId == user.Id);
            var candidate = await _candidateReadRepo.GetSingleAsync(x => x.UserId == user.Id);
            if(candidate != null)
                throw new DataNotAddedException("You can not be candidate again!!!");
            var election = await _electionReadRepo.Table.FirstOrDefaultAsync(
            x => x.DepartmentId == student.DepartmentId
            && DateTime.UtcNow < x.StartDate);

            if (election == null)
                throw new DataNotFoundException("There are no elections you can apply");

            var claims = new List<Claim>()
            {
                new Claim("role", UserRole.Candidate.ToString()),
                new Claim("isApproved", eDevletStatus ? ApproveStatus.Approved.ToString() : ApproveStatus.Rejected.ToString()),
            };

            var tokenResponse = _tokenService.CreateAccessToken(30, claims);
            user.UserRole = UserRole.Candidate;
            user.AccessToken = tokenResponse.AccessToken;
            user.RefreshToken = tokenResponse.RefreshToken;
            user.ExpirationDate = tokenResponse.ExpirationDate;
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
            await _candidateWriteRepo.SaveChangesAsync();
            return tokenResponse;
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

        //public async Task<GetCandidateResponse> GetCandidatesWhere(CandidateFilterRequest filter)
        //{
        //    var candidate = await _candidateReadRepo.GetWhere(c => c.);
        //    if (candidate == null)
        //        throw new DataNotFoundException(id);
        //    var candidateResponse = _mapper.Map<GetCandidateResponse>(candidate);
        //    return candidateResponse;
        //}

        public async Task<GetCandidateListResponse> GetCandidateListAsync()
        {
            var candidates = _candidateReadRepo.GetAll();
            var candidatesDto = _mapper.Map<List<CandidateDto>>(candidates);
            var response = await candidatesDto.ToGetCandidateListResponseAsync(_userReadRepo);
            //await Task.WhenAll(response);

            return response;
        }

        public async Task<TokenResponse> WithdrawCandidateAsync(string userName)
        {
            var claims = new List<Claim>()
            {
                new Claim("role", UserRole.Candidate.ToString()),
                new Claim("isApproved", ApproveStatus.Rejected.ToString()),
            };
            var tokenResponse = _tokenService.CreateAccessToken(30, claims);

            var user = await _userReadRepo.GetSingleAsync(x => x.UserName == userName);
            var candidate = await _candidateReadRepo.GetSingleAsync(x => x.UserId == user.Id);
            candidate.ApproveStatus = ApproveStatus.Rejected;
            user.RefreshToken = tokenResponse.RefreshToken;
            user.AccessToken = tokenResponse.AccessToken;
            user.ExpirationDate = tokenResponse.ExpirationDate;
            await _userWriteRepo.SaveChangesAsync();
            await _candidateWriteRepo.SaveChangesAsync();
            return tokenResponse;
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
