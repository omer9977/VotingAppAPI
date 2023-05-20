using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Election;
using Microsoft.AspNetCore.Authorization;


namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/election")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private readonly IElectionService _electionService;
        public ElectionController(
            IElectionService electionService
            )
        {
            _electionService = electionService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("department")]
        public async Task<IActionResult> CreateDepartmentElection([FromBody]CreateDepartmentElectionRequest createDepartmentElectionRequest)
        {
            var response = await _electionService.CreateDepartmentElection(createDepartmentElectionRequest);
            return Ok(response);
        }
    }
}
