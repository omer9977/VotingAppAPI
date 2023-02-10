using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Token;
using VotingAPI.Application.Dto.Request.Mail;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Exceptions;
using VotingAPI.Domain.Entities.Identity;
using VotingAPI.Persistence.Enums;

namespace VotingAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IMailService _mailService;

        private const string SchoolDomainGeneral = "SchoolDomain:General";
        private const string SchoolDomainStudent = "SchoolDomain:Student";
        private const string SchoolDomainEmployee = "SchoolDomain:Employee";

        public UserService(
            UserManager<AppUser> userManager,
            IMapper mapper,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            RoleManager<AppRole> roleManager,
            IStudentService studentService,
            IConfiguration configuration,
            IMailService mailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
            _studentService = studentService;
            _configuration = configuration;
            _mailService = mailService;
        }
        public async Task<bool> CreateUser(CreateUserRequest createUserRequest)
        {
            try
            {
                var user = _mapper.Map<AppUser>(createUserRequest);
                user.RefreshToken = _tokenService.CreateRefreshToken();
                user.RefreshTokenEndDate = DateTime.UtcNow.AddMinutes(5);
                IdentityResult result = await _userManager.CreateAsync(user, createUserRequest.Password);
                if (!result.Succeeded)//buradan dönen hata mesajları çıkmıyor
                    throw new Exception();// burada throw at
                await SendVerificationMailAsync(user.Email, user.RefreshToken);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoginUserResponse> Login(LoginUserRequest loginUserRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginUserRequest.Email);
            if (user == null)
                throw new UserNotFoundException();
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserRequest.Password, false);
            if (result.Succeeded)
            {
                List<string> userRole = (List<string>)await _userManager.GetRolesAsync(user);
                TokenResponse tokenResponse = _tokenService.CreateAccessToken(userRole, 5);//todo access token 5
                await UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.ExpirationDate, 5);//todo access token 5

                return new ()
                {
                    Token = tokenResponse
                };
            }
            throw new AuthenticationFailedException();
        }

        public async Task<bool> MailVerificationLoginAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null)
                throw new UserNotFoundException();
            if (user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                try
                {
                user.EmailConfirmed = true;//user manager save change yok kaydediliyormu kontrol et
                if (user.Email.EndsWith(_configuration[SchoolDomainStudent])) //todo string kontrolünün olması çok iyi değil, başka bir fikir bul
                {
                    var student = _mapper.Map<AddStudentRequest>(user);
                    await _userManager.UpdateAsync(user);
                    await _studentService.AddStudentAsync(student);
                    await _userManager.AddToRoleAsync(user, UserRoles.Student.ToString());
                    return true;
                }
                else if (user.Email.EndsWith(_configuration[SchoolDomainEmployee]))
                {
                    //employee logic
                }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                //eğer email domain i std içeriyorsa student servise bu user i ekle, eğer pers içeriyor ise bunu personel tablosuna ekle
            }
            else
            {

                //tekrar verification iste, bunun için tekrar başa dönülecek yani client üzerinden controller a tekrar istek gidecek. client üzerinde ilgili buton var olacak o butona tıklandığında bu servise gelecek
            }
            return false;
        }

        public async Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                List<string> userRole = (List<string>)await _userManager.GetRolesAsync(user);
                TokenResponse tokenResponse = _tokenService.CreateAccessToken(userRole, 5);//todo access token 5
                await UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.ExpirationDate, 5);
                return tokenResponse;
            }
            else
                throw new UserNotFoundException();
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTimeMinute)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(refreshTokenLifeTimeMinute);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new UserNotFoundException(user.UserName);
        }

        public async Task ResendVerificationByMailAsync(string refreshToken)//todo çok güzel bir logic olmadı
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(r => r.RefreshToken == refreshToken);
            if(user == null)
                throw new UserNotFoundException();
            user.RefreshToken = _tokenService.CreateRefreshToken();
            user.RefreshTokenEndDate = DateTime.UtcNow.AddMinutes(5);
            await SendVerificationMailAsync(user.Email, user.RefreshToken);
            await _userManager.UpdateAsync(user);
        }

        private async Task SendVerificationMailAsync(string toMail, string refreshToken)
        {
            MailRequest mailRequest = new() { ToEmail = toMail, Subject = "Email Verification", Body = $"To verify your mail please click this button: www.votingapiclient.com/{refreshToken}" };
            await _mailService.SendEmailAsync(mailRequest);
        }

    }
}
