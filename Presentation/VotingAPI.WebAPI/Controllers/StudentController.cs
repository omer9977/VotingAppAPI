using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Persistence.Repos;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/v1/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var response = _studentService.GetStudentList();
            return Ok(response);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] int id)
        {
            var response = await _studentService.GetStudentByIdAsync(id);
            return Ok(response);
        }

        //todo where koşulu gerektiği durumda isimlendirme doğru mu (filter yapabilirsin)
        //todo bu şekilde kullanım çok hoşuma gitmedi
        [Route("student-number/{studentNumber}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentByStudentNumberAsync([FromRoute] long studentNumber)
        {
            var response = await _studentService.GetStudentByStudentNumberAsync(studentNumber);
            return Ok(response);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(AddStudentRequest addStudentRequest)
        {
            await _studentService.AddStudentAsync(addStudentRequest);
            return StatusCode(201);
        }

        //[Route("")]
        //[HttpPut]
        //public async Task<IActionResult> UpdateStudentAsync(AddStudentRequest addStudentRequest)
        //{
        //    await _studentService.AddStudentAsync(addStudentRequest);
        //    return StatusCode(201);
        //}

        //[Route("")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteStudentAsync(AddStudentRequest addStudentRequest)
        //{
        //    await _studentService.AddStudentAsync(addStudentRequest);
        //    return StatusCode(201);
        //}



    }
}
