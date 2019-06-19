using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Base.Models;
using Base.Repositories;
using Base.Services;

namespace Base.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {

            _service = service;
        }

        // GET: api/roles
        [HttpGet]
        public IQueryable<Role> GetRoles()
        {
            return _service.FindAll();
        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _service.FindById(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        // PUT: api/roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            await _service.Update(id, role);
            return NoContent();
        }

        // POST: api/roles
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            await _service.Create(role);
            return CreatedAtAction("GetRole", new { id = role.Id }, role);
        }

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var role = await _service.FindById(id);
            if (role == null)
            {
                return NotFound();
            }
            await _service.Delete(id);
            return NoContent();
        }
    }
}
