using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Candidate
{
    public class GetCandidateListResponse
    {
        public ICollection<GetCandidateResponse> CandidateList { get; set; }
    }
}
