using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.User;

namespace VotingAPI.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMailService _mailService;
        public AuthController(
            //IUserService userService, 
            IAuthenticationService authenticationService,
            IMailService mailService
            )
        {
            //_userService = userService;
            _authenticationService = authenticationService;
            _mailService = mailService;
        }

        //Bu metod yeni bir kullanıcı eklemeye yarar. UI arayüzünden kullanıcı ilgili formu doldurup register butonuna tıklar ve onaylanması için onay maili alır bu endpoint ile.
        //onay maili ile refresh token oluşturulur 5dk lik. Eğer süre geçtiyse kullanıcı onaylanmaz
        //[Route("")]
        //[HttpPost]
        //public async Task<IActionResult> CreateUserAsync(CreateUserRequest createUserRequest)
        //{
        //    var response = await _userService.CreateUser(createUserRequest);
        //    return Ok(response);
        //}

        //Kullanıcı ekrana girmek için giriş yapar. Access token ve refresh token yenilenir. Elindeki access tokenin içinde role vardır o role a göre endpointlere bağlanır
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginUserRequest loginUserRequest)
        {
            //var user = await _userService.LoginAsync(loginUserRequest);
            var user = await _authenticationService.LoginAsync(loginUserRequest);
            return Ok(user);
        }

        //access token dolduğu zaman refresh token ile tekrar access token yaratılır. Buradaki şart refresh tokenin süresinin dolmamış olması
        //[Route("refresh-token-login")]
        //[HttpPost]
        //public async Task<IActionResult> RefreshTokenLoginAsync([FromForm]string refreshToken)
        //{
        //    var user = await _userService.RefreshTokenLoginAsync(refreshToken);
        //    return Ok(user);
        //}

        ////mail kutucuğuna karşısına bir buton çıktığı zaman o butona tıklarsa eğer yönlendirileceği sayfadaki client buraya istek gönderir
        ////kullanıcı onaylanır 
        //[Route("mail-verification-login")]
        //[HttpPost]
        //public async Task<IActionResult> MailVerificationLoginAsync([FromForm]string refreshToken)
        //{
        //    var user = await _userService.MailVerificationLoginAsync(refreshToken);
        //    return Ok(user);
        //}

        ////todo onemli: burayı daha sonra doldur
        //[Route("resend-mail-verification-login")]
        //[HttpPost]
        //public async Task<IActionResult> ResendMailVerificationLoginAsync([FromForm] string refreshToken)
        //{
        //    await _userService.ResendVerificationByMailAsync(refreshToken);
        //    return Ok();
        //}
    }
}
