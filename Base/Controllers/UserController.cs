using System.Threading.Tasks;
using Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Base.Repositories;
using Base.Services;

namespace Base.Controllers
{
    /// <summary>
    /// Users Controller
    /// </summary>
    [Authorize]
    [Route("api/users")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(404)]
    public class UserController : GenericController<User>
    {
        private readonly IUserRepository _repository;
        // private readonly IGenericService<User> _service;
        private readonly IUserService _service;


        /// <summary>
        /// Constructor
        /// </summary>
        // public UserController(IGenericService<User> service, IUserRepository repository) : base(service)
        public UserController(IUserService service, IUserRepository repository) : base(service)
        {
            _service = service;
            _repository = repository;
        }

        // GET: api/users/find-by-email/teste@teste.com
        /// <summary>
        /// Get a specific entity item by email
        /// </summary>
        /// <param name="email"></param>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [Route("find-by-email/{email}")]
        public async Task<ActionResult<User>> FindByEmail(string email)
        {
            // var entity = await _repository.FindByEmail(email);
            // if (entity == null)
            //     return NotFound();
            // return entity;

            var entity = await _service.FindByEmail(email);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;


        }

        // GET: api/users/find-by-username/teste
        /// <summary>
        /// Get a specific entity item by username
        /// </summary>
        /// <param name="username"></param>
        [HttpGet]
        [ProducesResponseType(200)]
        [Route("find-by-username/{username}")]
        public async Task<ActionResult<User>> FindByUsername(string username)
        {
            var entity = await _repository.FindByUsername(username);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
    }
}
