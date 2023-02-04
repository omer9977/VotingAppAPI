using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Application.Abstractions.Token
{
    public interface ITokenService
    {
        TokenResponse CreateAccessToken(int minute);
        string CreateRefreshToken();
        //Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTimeMinute);
        //Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken);
    }
}
