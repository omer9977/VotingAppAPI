using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.User
{
    public class LoginUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
