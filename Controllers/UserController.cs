using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Base.Helpers;
using Base.Repositories;

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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/users
        /// <summary>
        /// Get all entity itens
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        public IQueryable<User> Index()
        {
            return _repository.GetAll();
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
            var entity = await _repository.FindByEmail(email);
            if (entity == null)
                return NotFound();
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

        // GET: api/users/5
        /// <summary>
        /// Get a specific entity item
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<User>> Show(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // POST: api/users
        /// <summary>
        /// Create a specific entity item
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> Store(User entity)
        {
            entity.Password = Secret.GenerateHash(entity.Password);
            await _repository.Create(entity);
            return CreatedAtAction(nameof(Show), new { id = entity.Id }, entity);
        }

        // PUT: api/users/5
        /// <summary>
        /// Update a specific entity item
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="entity">form body</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(int id, User entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _repository.Update(id, entity);
            return NoContent();
        }

        // DELETE: api/users/5
        /// <summary>
        /// Deletes a specific entity item
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Destroy(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
