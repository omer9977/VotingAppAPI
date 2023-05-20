using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Enums;

namespace VotingAPI.Application.Dto.Request.Candidate
{
    public class AddCandidateFileRequest
    {
        public int CandidateId { get; set; }
        public FileTypes FileTypeId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
