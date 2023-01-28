using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Features.Commands.AddDepartment;
using VotingAPI.Application.Features.Queries.GetAllDepartments;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/Departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentReadRepo _departmentReadRepo;
        private readonly IDepartmentWriteRepo _departmentWriteRepo;
        private readonly IMediator _mediator;
        public DepartmentsController(IDepartmentReadRepo departmentReadRepo, IDepartmentWriteRepo departmentWriteRepo, IMediator mediator = null)
        {
            _departmentReadRepo = departmentReadRepo;
            _departmentWriteRepo = departmentWriteRepo;
            _mediator = mediator;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllDepartmentsQueryResponse response = await _mediator.Send(new GetAllDepartmentsQueryRequest());
            return Ok(response);
        }
        [Route("GetById")]
        [HttpGet]
        public async Task GetById()
        {
            Department d = await _departmentReadRepo.GetByIdAsync(1);
            d.Name = "Physics";
            await _departmentWriteRepo.SaveChangesAsync();

        }
        [Route("AddRange")]
        [HttpPost]
        public async Task AddRange()
        {
            _departmentWriteRepo.AddRangeAsync(new() {
            new(){Id = 1, Name = "Computer Engineering"},
            new(){Id = 2, Name = "Mechanical Engineering"},
            new(){Id = 3, Name = "Chemical Engineering"}
            });
            await _departmentWriteRepo.SaveChangesAsync();
        }

        [Route("AddDepartment")]
        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentRequest addDepartmentRequest)
        {

            return Ok();
        }

    }
}
