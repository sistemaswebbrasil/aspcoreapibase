using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Base.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// </summary>
    [Authorize]
    [Route("api/")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private IAuthServices _authService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticates the user
        /// </summary>
        /// <param name="request">TokenRequest is object with email and password</param>
        /// <returns>AuthUser</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<User> Authenticate([FromBody] TokenRequest request)
        {
            var user = _authService.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        /// <summary>
        /// Register new user in system
        /// </summary>
        /// <param name="userParam">User form</param>
        /// <returns>User</returns>
        [AllowAnonymous]
        [HttpPost("sigup")]
        public ActionResult<User> Signup(User userParam)
        {
            var user = _authService.Signup(userParam);

            if (user == null)
                return BadRequest();

            return CreatedAtAction(nameof(Authenticate), user);
        }
    }
}
