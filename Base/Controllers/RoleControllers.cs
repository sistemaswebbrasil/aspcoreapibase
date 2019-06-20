using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Base.Models;
using Base.Services;

namespace Base.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase, IGenericController<Role>
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {

            _service = service;
        }


        // GET: api/roles
        [HttpGet]
        public IQueryable<Role> Index()
        {
            return _service.FindAll();
        }

        // GET: api/roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Show(int id)
        {
            var role = await _service.FindById(id);
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        // POST: api/roles
        [HttpPost]
        public async Task<ActionResult<Role>> Store(Role entity)
        {
            await _service.Create(entity);
            return CreatedAtAction("GetRole", new { id = entity.Id }, entity);
        }

        // PUT: api/roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Role entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _service.Update(id, entity);
            return NoContent();
        }

        // DELETE: api/roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
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
