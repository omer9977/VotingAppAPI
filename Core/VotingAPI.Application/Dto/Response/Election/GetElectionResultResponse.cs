using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Response.Candidate;

namespace VotingAPI.Application.Dto.Response.Election
{
    public class GetElectionResultResponse
    {
        public ICollection<GetCandidateElectionResponse> CandidateElectionResultList { get; set; }
        public string Message { get; set; }
    }
}
