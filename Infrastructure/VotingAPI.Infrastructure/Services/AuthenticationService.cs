using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Token;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;
//using VotingAPI.Domain.Entities.Identity;
using VotingAPI.ObsService.Interfaces;

namespace VotingAPI.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {//todo bu servisin persistence içerisinde olması lazım
        //private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IObsStudentService _obsStudentService;
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;


        public AuthenticationService(
            //UserManager<AppUser> userManager,
            IMapper mapper,
            //SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IObsStudentService obsStudentService,
            IStudentService studentService,
            IDepartmentService departmentService,
            IUserReadRepo userReadRepo,
            IUserWriteRepo userWriteRepo,
            IUserService userService
            )
        {
            //_userManager = userManager;
            _mapper = mapper;
            //_signInManager = signInManager;
            _tokenService = tokenService;
            _obsStudentService = obsStudentService;
            _studentService = studentService;
            _departmentService = departmentService;
            _userService = userService;
        }
        //public async Task<bool> CreateUser(CreateUserRequest createUserRequest)
        //{
        //    var user = _mapper.Map<AppUser>(createUserRequest);
        //    IdentityResult result = await _userManager.CreateAsync(user, createUserRequest.Password);
        //    if (result.Succeeded)
        //    {
        //        return true;

        //    }
        //    return false;
        //}

        public async Task<LoginUserResponse> LoginAsync(LoginUserRequest loginUserRequest)
        {
            var user = _obsStudentService.FindUserByUserName(loginUserRequest.UserName);
            if (user == null)
            {
                var personal = await _userService.GetUserByUserNameAsync(loginUserRequest.UserName);
                if (personal == null)
                    throw new UserNotFoundException();
                TokenResponse token = new();
                if (loginUserRequest.Password == personal.Password)
                {
                    token = _tokenService.CreateAccessToken(userRole: new List<string>() { personal.UserRole.ToString() }, minute: 5);
                }
                return new() { LastName = personal.LastName, UserRole = personal.UserRole.ToString(), Name = personal.Name, Token =  token };
            }
            var student = await _studentService.GetStudentByUserNameAsync(loginUserRequest.UserName);
            TokenResponse tokenResponse = new();
            if (user.PasswordHash == loginUserRequest.Password)
            {
                //List<string> userRole = (List<string>)await _userManager.GetRolesAsync(user);
                tokenResponse = _tokenService.CreateAccessToken(userRole: new List<string>() { "Student" }, minute: 5); //todo deneme

                //await UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.ExpirationDate, 5);//todo access token 5
                //return new()
                //{
                //    Token = tokenResponse
                //};
            }
            var department = _departmentService.GetDepartmentsWhere(u => u.Name == user.Department).Result.FirstOrDefault();
            if (student != null)
            {
                return new() { Token = tokenResponse, 
                    DepartmentName = department.Name, 
                    Name = user.Name, 
                    LastName = user.LastName, 
                    UserRole = student.UserRole.ToString() };
            }
            await _userService.AddUserAsync(new() { 
                LastName = user.LastName, 
                Name = user.Name, 
                UserRole = UserRole.Student, 
                Password = user.PasswordHash, 
                UserName = user.UserName,
                AccessToken = tokenResponse.AccessToken,
                ExpirationDate = tokenResponse.ExpirationDate,
                RefreshToken = tokenResponse.RefreshToken
            });

            var userDb = await _userService.GetUserByUserNameAsync(user.UserName);
            var addStudentRequest = new AddStudentRequest()
            {
                DepartmentId = department?.Id,
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                Year = user.Year,
                UserId = userDb.Id
            };
            await _studentService.AddStudentAsync(addStudentRequest);

            //var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserRequest.Password, false);
            //if (result.Succeeded)
            //{
            //    TokenResponse tokenResponse = _tokenService.CreateAccessToken(5);
            //    return new()
            //    {
            //        Token = tokenResponse
            //    };
            //}
            //throw new AuthenticationFailedException();
            return new() { 
                Token = tokenResponse,
                UserRole = userDb.UserRole.ToString(),
                DepartmentName = department?.Name,
                Name = user.Name,
                LastName = user.LastName
            };
        }
    }
}
