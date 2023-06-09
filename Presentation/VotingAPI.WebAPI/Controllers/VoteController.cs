using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Votes;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/vote")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetVotesAsync()
        {
            var response = _voteService.GetVoteList();
            return Ok(response);
        }


        [HttpPost]
        //[Authorize(Roles = "Student")]
        [Route("")]
        public async Task<IActionResult> AddVote(AddVoteRequest addVoteRequest)
        {
            await _voteService.AddVote(addVoteRequest);
            return Ok();
        }
    }
}
