using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response
{
    public class ResultData<T> : Result where T : class
    {
        public T? Data { get; set; }
    }
}
