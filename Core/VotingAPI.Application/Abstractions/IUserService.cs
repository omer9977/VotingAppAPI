using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Application.Abstractions
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserRequest createUserRequest);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTimeMinute);
        Task<LoginUserResponse> Login(LoginUserRequest loginUserRequest);
        Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken);
    }
}
