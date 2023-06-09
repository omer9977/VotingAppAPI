using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Candidate
{
    public class GetCandidateElectionResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int VoteNumber { get; set; }
    }
}
