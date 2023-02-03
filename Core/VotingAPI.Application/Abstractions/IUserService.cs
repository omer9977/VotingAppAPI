using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;

namespace VotingAPI.Application.Abstractions
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserRequest createUserRequest);
        Task<LoginUserResponse> Login(LoginUserRequest loginUserRequest);
    }
}
