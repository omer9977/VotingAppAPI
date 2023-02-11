using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Request.Votes
{
    public class AddVoteRequest
    {
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        [ForeignKey("Candidates")]
        public int CandidateId { get; set; }
        [ForeignKey("VotingPeriods")]
        public int VotingPeriodId { get; set; }
    }
}
