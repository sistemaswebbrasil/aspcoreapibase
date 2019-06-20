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
        private IAuthServices _service;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="service"></param>
        public AuthController(IAuthServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Authenticates the user
        /// </summary>
        /// <param name="request">TokenRequest is object with email and password</param>
        /// <returns>AuthUser</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<User>> Authenticate([FromBody] TokenRequest request)
        {
            var user = await _service.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(user);
        }

        /// <summary>
        /// Register new user in system
        /// </summary>
        /// <param name="user">User form</param>
        /// <returns>User</returns>
        [AllowAnonymous]
        [HttpPost("sigup")]
        public async Task<ActionResult<User>> Signup(User user)
        {
            await _service.Signup(user);
            return CreatedAtAction("Authenticate", user);
        }
    }
}
