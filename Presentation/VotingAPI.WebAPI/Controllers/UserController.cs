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
        private readonly IMailService _mailService;
        public UserController(IUserService userService, IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
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

        [Route("refresh-token-login")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenLogin([FromForm]string refreshToken)
        {
            var user = await _userService.RefreshTokenLoginAsync(refreshToken);
            return Ok(user);
        }

        [Route("mail")]
        [HttpPost]
        public async Task<IActionResult> Mail()
        {
            await _mailService.SendMessageAsync("omerbilgin1999@gmail.com", "Örnek Email", "Bu bir örnek maildir", false);
            return Ok();
        }
    }
}
