using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base(ResultMessages.UserNotFound) { }

        public UserNotFoundException(string? message) : base(message)
        {
        }
    }
}
