using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.User;

namespace VotingAPI.Application.Abstractions
{
    public interface IUserService
    {
        Task<bool> CreateUser(CreateUserRequest createUserRequest);
    }
}
