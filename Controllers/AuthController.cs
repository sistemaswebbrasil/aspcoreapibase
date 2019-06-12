using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Base.Controllers {
    [Authorize]
    [Route ("api/")]
    public class AuthController : ControllerBase {
        private IUserService _userService;

        public AuthController (IUserService userService) {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost ("login")]
        public IActionResult Authenticate ([FromBody] User userParam) {
            var user = _userService.Authenticate (userParam.Email, userParam.Password);

            if (user == null)
                return BadRequest (new { message = "Email or password is incorrect" });

            return Ok (user);
        }

    }
}
