using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Announcement;
using VotingAPI.Application.Dto.Response.Announcement;

namespace VotingAPI.Application.Abstractions
{
    public interface IAnnouncementService
    {
        public Task<GetAnnouncementListResponse> GetAnnouncementList();
        public Task<bool> CreateAnnouncement(AddAnnouncementRequest addAnnouncementRequest);
    }
}
