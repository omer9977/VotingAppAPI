using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Abstractions.Token;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Exceptions;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Persistence.Services
{
    public class UserService : IUserService
    {//todo bu servisin persistence içerisinde olması lazım
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public UserService(
            UserManager<AppUser> userManager,
            IMapper mapper,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<bool> CreateUser(CreateUserRequest createUserRequest)
        {
            try
            {
            var user = _mapper.Map<AppUser>(createUserRequest);
            IdentityResult result = await _userManager.CreateAsync(user, createUserRequest.Password);
            if (!result.Succeeded)//buradan dönen hata mesajları çıkmıyor
                throw new Exception();// burada throw at
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
                TokenResponse tokenResponse = _tokenService.CreateAccessToken(5);//todo access token 5
                UpdateRefreshToken(tokenResponse.RefreshToken, user, tokenResponse.ExpirationDate, 5);//todo access token 5

                return new ()
                {
                    Token = tokenResponse
                };
            }
            throw new AuthenticationFailedException();
        }
        public async Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenResponse tokenResponse = _tokenService.CreateAccessToken(5);//todo access token 5
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
    }
}
