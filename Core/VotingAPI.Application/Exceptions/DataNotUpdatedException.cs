using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class DataNotUpdatedException : Exception
    {
        public DataNotUpdatedException()
    : base(ResultMessages.DataNotUpdated) { }

        public DataNotUpdatedException(string? message) : base(message)
        {
        }
    }
}
