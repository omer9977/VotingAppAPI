using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(object id)
            : base($"{id} id object could not be found.") { }

        public DataNotFoundException(string? message) : base(message)
        {
        }
    }
}
