using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Base.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<User> Authenticate(TokenRequest userParam)
        {
            var user = _authService.Authenticate(userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("sigup")]
        public ActionResult<User> Signup(User userParam)
        {
            var user = _authService.Signup(userParam);

            if (user == null)
                return BadRequest();

            return NoContent();

        }
    }
}
