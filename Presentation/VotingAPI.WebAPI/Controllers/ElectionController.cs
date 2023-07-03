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

        [Authorize(Roles = "Admin")]
        [HttpPost("department")]
        public async Task<IActionResult> CreateDepartmentElection([FromBody]CreateDepartmentElectionRequest createDepartmentElectionRequest)
        {
            var response = await _electionService.CreateDepartmentElectionAsync(createDepartmentElectionRequest);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("department")]
        public async Task<IActionResult> GetDepartmentElections()
        {
            var response = await _electionService.GetAllDepartmentElectionsAsync(null);
            return Ok(response);
        }

        [HttpGet("department/{departmentName?}")]
        public async Task<IActionResult> GetDepartmentElections([FromRoute] string? departmentName)
        {
            var response = await _electionService.GetAllDepartmentElectionsAsync(departmentName);
            return Ok(response);
        }

        [HttpGet("{electionId}/candidate")]
        public async Task<IActionResult> GetCandidatesByElectionId([FromRoute] int electionId)
        {
            var response = await _electionService.GetCandidatesByElectionIdAsync(electionId);
            return Ok(response);
        }

        [HttpGet("{electionId}/result")]
        public async Task<IActionResult> GetResultByElectionId([FromRoute] int electionId)
        {
            var response = await _electionService.GetResultByElectionIdAsync(electionId);
            return Ok(response);
        }

        [HttpPut("{electionId}")]
        public async Task<IActionResult> UpdateElection([FromRoute] int electionId ,[FromBody] UpdateDepartmentElectionRequest updateDepartmentElectionRequest)
        {
            var response = await _electionService.UpdateElectionAsync(electionId, updateDepartmentElectionRequest);
            return Ok(response);
        }

        [HttpDelete("{electionId}")]
        public async Task<IActionResult> DeleteElection([FromRoute] int electionId)
        {
            var response = await _electionService.DeleteElectionAsync(electionId);
            return Ok(response);
        }


        [HttpPatch("{electionId}/finish")]
        public async Task<IActionResult> FinishElectionAsync([FromRoute] int electionId)
        {
            var response = await _electionService.FinishElectionAsync(electionId);
            return Ok(response);
        }
        [HttpPatch("{electionId}/re-election")]
        public async Task<IActionResult> StartReElectionAsync([FromRoute] int electionId, [FromBody] StartReElectionRequest updateDepartmentElectionRequest)
        {
            var response = await _electionService.StartReElectionAsync(electionId, updateDepartmentElectionRequest.EndDate);//todo bura çok garip olmuş çünkü UpdateDepartmentElectionRequest bunun sadece bir değeri gönderiliyor servise
            return Ok(response);
        }
    }
}
