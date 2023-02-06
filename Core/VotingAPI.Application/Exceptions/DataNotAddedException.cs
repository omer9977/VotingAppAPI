using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class DataNotAddedException : Exception
    {
        public DataNotAddedException()
            : base(ResultMessages.NotAddedRecord) { }

        public DataNotAddedException(string? message) : base(message)
        {
        }
    }
}
