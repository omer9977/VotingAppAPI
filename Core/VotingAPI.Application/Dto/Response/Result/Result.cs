using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response
{
    public class Result
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; } = null;
    }
}
