using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Request.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? RefreshToken { get; set; }
    }
}
