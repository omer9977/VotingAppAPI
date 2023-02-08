using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class TokenExpiredException : Exception
    {
        public TokenExpiredException()
    : base(ResultMessages.TokenExpired) { }

        public TokenExpiredException(string? message) : base(message)
        {
        }
    }
}
