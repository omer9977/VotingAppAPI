using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.General
{
    public class VoteDto
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
        public int ElectionId { get; set; }
    }
}
