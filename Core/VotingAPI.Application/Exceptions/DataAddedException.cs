using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class DataAddedException : Exception
    {
        public DataAddedException()
            : base(ResultMessages.NotAddedRecord) { }

        public DataAddedException(string? message) : base(message)
        {
        }
    }
}
