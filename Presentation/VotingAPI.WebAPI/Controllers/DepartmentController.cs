using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/department")]
    [ApiController]
    //[Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMediator _mediator;
        //private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService, IMediator mediator = null)
        {
            _departmentService = departmentService;
            _mediator = mediator;
        }

        [Route("")]
        //[Authorize(Roles = "Student")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _departmentService.GetDepartmentList();
            return Ok(response);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDepartmentByIdAsync(int id)
        {
            var response = await _departmentService.GetDepartmentByIdAsync(id);
            return Ok(response);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddDepartmentAsync(AddDepartmentRequest addDepartmentRequest)
        {
            bool isAdded = await _departmentService.AddDepartmentAsync(addDepartmentRequest);
            return StatusCode(201);
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> UpdateDepartmentAsync(UpdateDepartmentRequest updateDepartmentRequest)
        {
            bool isUpdated = await _departmentService.UpdateDepartmentAsync(updateDepartmentRequest);
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartmentByIdAsync([FromRoute]int id)
        {
            bool isDeleted = await _departmentService.DeleteDepartmentAsync(id);
            return Ok();
        }
    }
}
