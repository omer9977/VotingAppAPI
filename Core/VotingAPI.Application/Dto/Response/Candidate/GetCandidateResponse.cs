﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Candidate
{
    public class GetCandidateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public long SchoolNumber { get; set; }
        public string Email { get; set; }
        public DateOnly ApplicationDate { get; set; }
        public short ApproveStatus { get; set; }
    }
}
