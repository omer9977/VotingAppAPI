using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Response.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
