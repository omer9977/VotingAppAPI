using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.User
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string RefreshToken { get; set; }
    }
}
