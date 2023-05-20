using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.ProfilePhoto
{
    public class GetFileResponse
    {
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
