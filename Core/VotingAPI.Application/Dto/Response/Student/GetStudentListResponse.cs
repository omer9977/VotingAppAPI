﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Student
{
    public class GetStudentListResponse
    {
        public List<GetStudentResponse> Students { get; set; }
    }
}
