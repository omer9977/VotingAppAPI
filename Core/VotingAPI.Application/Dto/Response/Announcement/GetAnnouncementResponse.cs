using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Announcement
{
    public class GetAnnouncementResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
    }
}
