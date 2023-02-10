using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.File
{
    public class AddFileRequest
    {
        public int CandidateId { get; set; }
        public short FileTypeId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
