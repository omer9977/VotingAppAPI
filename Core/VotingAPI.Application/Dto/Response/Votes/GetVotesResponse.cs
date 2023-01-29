using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Votes
{
    public class GetVotesResponse
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
        public int DepartmentId { get; set; }
        public int VotingPeriodId { get; set; }
        public DateTime VotingDate { get; set; }
    }
}
