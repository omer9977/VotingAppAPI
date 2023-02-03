using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Response.User;

namespace VotingAPI.Application.Abstractions.Token
{
    public interface ITokenService
    {
        TokenResponse CreateAccessToken();
    }
}
