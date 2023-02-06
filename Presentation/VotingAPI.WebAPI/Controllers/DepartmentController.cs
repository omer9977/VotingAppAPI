using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Features.Commands.AddDepartment;
using VotingAPI.Application.Features.Queries.GetAllDepartments;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/department")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentReadRepo _departmentReadRepo;
        private readonly IDepartmentWriteRepo _departmentWriteRepo;
        private readonly IMediator _mediator;
        //private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentReadRepo departmentReadRepo, IDepartmentWriteRepo departmentWriteRepo, IMediator mediator = null)
        {
            _departmentReadRepo = departmentReadRepo;
            _departmentWriteRepo = departmentWriteRepo;
            _mediator = mediator;
        }

        [Route("")]
        [Authorize(Roles = "Student")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllDepartmentsQueryResponse response = await _mediator.Send(new GetAllDepartmentsQueryRequest());
            return Ok(response);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task GetById()
        {
            Department d = await _departmentReadRepo.GetByIdAsync(1);
            d.Name = "Physics";
            await _departmentWriteRepo.SaveChangesAsync();

        }
        [Route("list")]
        [HttpPost]
        public async Task AddDepartmentList()
        {
            _departmentWriteRepo.AddRangeAsync(new() {
            new(){Id = 1, Name = "Computer Engineering"},
            new(){Id = 2, Name = "Mechanical Engineering"},
            new(){Id = 3, Name = "Chemical Engineering"}
            });
            await _departmentWriteRepo.SaveChangesAsync();
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentRequest addDepartmentRequest)
        {

            return Ok();
        }

    }
}
