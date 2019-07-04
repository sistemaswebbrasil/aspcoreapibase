using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
                return Unauthorized(new { message = "Email or password is incorrect" });

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

        /// <summary>
        /// Showing user data logged in
        /// </summary>
        /// <returns>AuthUser</returns>
        [HttpGet("profile")]
        public async Task<ActionResult<AuthUser>> Profile()
        {   
            AuthUser authUser = await _service.profile();
            if (authUser == null)
            {
                return Unauthorized();
            }
            return authUser;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [AllowAnonymous]
        [Route("username-available/{username}")]
        public async Task<ActionResult<object>> UsernameAvailable(string username)
        {
            var avaliable = await _service.UsernameAvailable(username);
            return Ok(new { avaliable = avaliable });
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [AllowAnonymous]
        [Route("email-available/{email}")]
        public async Task<ActionResult<bool>> EmailAvailable(string email)
        {
            var avaliable = await _service.EmailAvailable(email);
            return Ok(new { avaliable = avaliable });
        }
    }
}
