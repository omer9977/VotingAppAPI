using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.VotingPeriod;
using VotingAPI.Application.Repositories.ModelRepos;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/votingperiod")]
    [ApiController]
    public class VotingPeriodController : ControllerBase
    {
        private readonly IVotingPeriodService _votingPeriodService;
        public VotingPeriodController(IVotingPeriodService votingPeriodService)
        {
            _votingPeriodService = votingPeriodService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAllVotingPeriods()
        {
            var response = _votingPeriodService.GetVotingPeriodList();
            return Ok(response);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddVotingPeriodAsync(AddVotingPeriodRequest addVotingPeriodRequest)
        {
            var response = await _votingPeriodService.AddVotingPeriodAsync(addVotingPeriodRequest);
            return Ok(response);
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> UpdateVotingPeriodAsync(UpdateVotingPeriodRequest updateVotingPeriodRequest)
        {
            var response = await _votingPeriodService.UpdateVotingPeriodAsync(updateVotingPeriodRequest);
            return Ok(response);
        }
    }
}
