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
        List<GetUserResponse> GetUserList();
        Task<GetUserResponse> GetUserByIdAsync(int id);
        Task<GetUserResponse> GetUserByUserNameAsync(string userName);
        Task AddUserAsync(CreateUserRequest addUserRequest);
        Task DeleteUserAsync(int id);
    }
}
