using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Request.Candidate
{
    public class CandidateFilterRequest
    {
        public ApproveStatus ApproveStatus { get; set; }
        public int ElectionId { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
    }
}
