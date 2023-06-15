using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Announcement
{
    public class GetAnnouncementListResponse
    {
        public ICollection<GetAnnouncementResponse> AnnouncementList { get; set; }
    }
}
