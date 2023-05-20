using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Request.VotingPeriod
{
    public class AddVotingPeriodRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ElectionTypeId { get; set; }
    }
}
