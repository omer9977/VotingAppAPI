using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;
//using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Application.Abstractions
{
    public interface IAuthenticationService
    {
        //Task<bool> CreateUser(CreateUserRequest createUserRequest);
        //Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int refreshTokenLifeTimeMinute);
        Task<LoginUserResponse> LoginAsync(LoginUserRequest loginUserRequest);
        //Task<TokenResponse> RefreshTokenLoginAsync(string refreshToken);
        //Task<bool> MailVerificationLoginAsync(string refreshToken);
        //Task ResendVerificationByMailAsync(string refreshToken);//todo çok güzel bir logic olmadı
        //public Task<GetUserResponse> GetAllStudents();


    }
}
