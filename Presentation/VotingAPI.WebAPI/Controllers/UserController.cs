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
        public async Task<IActionResult> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var response = await _userService.CreateUser(createUserRequest);
            return Ok(response);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginUserRequest loginUserRequest)
        {
            var user = await _userService.Login(loginUserRequest);
            return Ok(user);
        }

        [Route("refresh-token-login")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenLoginAsync([FromForm]string refreshToken)
        {
            var user = await _userService.MailVerificationLoginAsync(refreshToken);
            return Ok(user);
        }

        [Route("mail-verification-login")]
        [HttpPost]
        public async Task<IActionResult> MailVerificationLoginAsync([FromForm]string refreshToken)
        {
            var user = await _userService.MailVerificationLoginAsync(refreshToken);
            return Ok(user);
        }

        [Route("resend-mail-verification-login")]
        [HttpPost]
        public async Task<IActionResult> ResendMailVerificationLogin([FromForm] string refreshToken)
        {
            await _userService.ResendVerificationByMailAsync(refreshToken);
            return Ok();
        }

        [Route("mail")]
        [HttpPost]
        public async Task<IActionResult> Mail()
        {
            //await _mailService.SendEmailAsync("omerbilgin1999@gmail.com", "Örnek Email", "Bu bir örnek maildir", false);
            return Ok();
        }
    }
}
