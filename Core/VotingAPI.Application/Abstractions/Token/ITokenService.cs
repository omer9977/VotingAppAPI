using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Response.User;

namespace VotingAPI.Application.Abstractions.Token
{
    public interface ITokenService
    {
        //TokenResponse CreateAccessToken(List<string> userRole, int minute);
        TokenResponse CreateAccessToken(int minute, List<string> userRole = null); //todo daha sonrasında userRole ayarla

        string CreateRefreshToken();
        //Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTimeMinute);
        //Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken);
    }
}
