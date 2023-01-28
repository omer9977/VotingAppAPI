using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Persistence.Repos;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        //[Route("AddRange")]
        //[HttpPost]
        //public async Task AddRange()
        //{
        //    await _studentWriteRepo.AddRangeAsync(new() {
        //    new(){Id = 1, StudentNumber = 270,Name="ömer" },
        //    new(){Id = 2, StudentNumber = 250,Name="asdf" },
        //    new(){Id = 3, StudentNumber = 260,Name="wefe" },


        //    });
        //    await _studentWriteRepo.SaveChangesAsync();
        //}

        [Route("AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(AddStudentRequest addStudentRequest)
        {
            var response = _studentService.AddStudentAsync(addStudentRequest);
            return Ok(response);
        }
    }
}
