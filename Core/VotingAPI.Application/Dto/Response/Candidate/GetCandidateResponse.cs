using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Candidate
{
    public class GetCandidateResponse
    {
        public int Id { get; set; }
        public long StudentNumber { get; set; }
        public string Name { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public short ApproveStatus { get; set; }
    }
}
