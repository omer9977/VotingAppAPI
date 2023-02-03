using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.User;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            var response = await _userService.CreateUser(createUserRequest);
            return Ok(response);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var user = await _userService.Login(loginUserRequest);
            return Ok(user);
        }
    }
}
