using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Application.Dto.Response.Candidate
{
    public class AddCandidateResponse
    {
        public string Name { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public short ApproveStatus { get; set; }
    }
}
