using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<bool> CreateUser(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<AppUser>(createUserRequest);
            IdentityResult result = await _userManager.CreateAsync(user, createUserRequest.Password);
            if (result.Succeeded)
            {
            return true;

            }
            return false;
        }
    }
}
