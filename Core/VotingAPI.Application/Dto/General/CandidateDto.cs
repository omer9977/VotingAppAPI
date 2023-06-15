using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.General
{
    public class CandidateDto
    {
        public ApproveStatus ApproveStatus { get; set; }
        public int ElectionId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
