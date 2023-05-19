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
using VotingAPI.Domain.Entities.Identity;
using VotingAPI.ObsService.Interfaces;

namespace VotingAPI.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {//todo bu servisin persistence içerisinde olması lazım
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IObsStudentService _obsStudentService;
        private readonly IStudentService _studentService;

        public AuthenticationService(
            UserManager<AppUser> userManager,
            IMapper mapper,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IObsStudentService obsStudentService,
            IStudentService studentService
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _obsStudentService = obsStudentService;
            _studentService = studentService;
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
            //var user = await _userManager.FindByEmailAsync(loginUserRequest.Email);
            var user = _obsStudentService.FindUserByUserName(loginUserRequest.Email);
            if (user == null)
                throw new UserNotFoundException();
            var userDb = _studentService.GetStudentByUserNameAsync(loginUserRequest.Email);
            if (userDb == null)
            {

            }
            var addStudentRequest = new AddStudentRequest() 
            {
                //DepartmentId = user.Department,
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                Year = user.Year,
            };
            await _studentService.AddStudentAsync(user);
            if (user.PasswordHash == loginUserRequest.Password)
            {
                //List<string> userRole = (List<string>)await _userManager.GetRolesAsync(user);
                TokenResponse tokenResponse = _tokenService.CreateAccessToken(minute: 5);

                //await UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.ExpirationDate, 5);//todo access token 5
                return new()
                {
                    Token = tokenResponse
                };
            }

            //var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserRequest.Password, false);
            //if (result.Succeeded)
            //{
            //    TokenResponse tokenResponse = _tokenService.CreateAccessToken(5);
            //    return new()
            //    {
            //        Token = tokenResponse
            //    };
            //}
            throw new AuthenticationFailedException();
        }
    }
}
