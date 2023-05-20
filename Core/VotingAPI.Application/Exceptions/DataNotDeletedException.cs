using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class DataNotDeletedException : Exception
    {
        public DataNotDeletedException()
            : base(ResultMessages.DataNotDeleted) { }

        public DataNotDeletedException(string? message) : base(message)
        {
        }
    }
}
