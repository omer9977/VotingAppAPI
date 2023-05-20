using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Response.VotingPeriod
{
    public class GetVotingPeriodResponse
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int ElectionTypeName { get; set; }
    }
}
