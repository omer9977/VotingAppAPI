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
            : base(ResultMessages.PropertyNotFound(nameof(id))) { }

        public DataNotFoundException(string? message) : base(message)
        {
        }
    }
}
