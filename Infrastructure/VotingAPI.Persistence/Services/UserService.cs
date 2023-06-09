using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserReadRepo _userReadRepo;
        private readonly IUserWriteRepo _userWriteRepo;
        public UserService(
            IMapper mapper,
            IUserReadRepo userReadRepo,
            IUserWriteRepo userWriteRepo
            )
        {
            _mapper = mapper;
            _userReadRepo = userReadRepo;
            _userWriteRepo = userWriteRepo;
        }
        public async Task AddUserAsync(CreateUserRequest addUserRequest)
        {
            var userMapped = _mapper.Map<User>(addUserRequest);
            await _userWriteRepo.AddAsync(userMapped);
            await _userWriteRepo.SaveChangesAsync();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserResponse> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserResponse> GetUserByUserNameAsync(string userName)
        {
            var user =  _userReadRepo.Table.FirstOrDefault(x => x.UserName == userName);
            var userMapped = _mapper.Map<GetUserResponse>(user);
            return userMapped;
        }

        public List<GetUserResponse> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
