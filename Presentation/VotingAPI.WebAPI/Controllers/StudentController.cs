using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Student;
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

        [Route("AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(AddStudentRequest addStudentRequest)
        {
            var response = await _studentService.AddStudentAsync(addStudentRequest);
            return Ok(response);
        }

        [Route("GetStudentByStudentNumber")]
        [HttpGet]
        public async Task<IActionResult> GetStudentByStudentNumberAsync(long studentNumber)
        {
            var response =  await _studentService.GetStudentByStudentNumber(studentNumber);
            return Ok(response);
        }

        [Route("GetStudentAllStudents")]
        [HttpGet]
        public IActionResult GetStudentList()
        {
            var response = _studentService.GetStudentList();
            return Ok(response);
        }
    }
}
