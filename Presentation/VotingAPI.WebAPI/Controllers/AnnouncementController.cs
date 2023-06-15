using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Announcement;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAnnouncements()
        {
            var response = await _announcementService.GetAnnouncementListAsync();
            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAnnouncement(AddAnnouncementRequest addAnnouncementRequest)
        {
            var response = await _announcementService.CreateAnnouncementAsync(addAnnouncementRequest);
            return Ok(response);
        }
    }
}
