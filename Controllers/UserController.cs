using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Base.Models;

namespace Base.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Index()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Show(uint id)
        {
            var entity = await _context.Users.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> Store(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Show), new { id = entity.Id }, entity);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(uint id, User entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(uint id)
        {
            var entity = await _context.Users.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}