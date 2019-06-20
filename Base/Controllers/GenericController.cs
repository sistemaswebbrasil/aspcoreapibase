using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Base.Services;
using Base.Models;

namespace Base.Controllers
{
    /// <summary>
    /// Generic controller class
    /// </summary>
    /// <typeparam name="TEntity">Entities that implement ITrackable</typeparam>
    [ApiController]
    public class GenericController<TEntity> : ControllerBase, IGenericController<TEntity>
        where TEntity : class, ITrackable
    {
        private readonly IGenericService<TEntity> _service;

        public GenericController(IGenericService<TEntity> service)
        {
            _service = service;
        }

        /// <summary>
        /// List the entity records
        /// </summary>
        /// <returns>json array</returns>
        [HttpGet]
        public IQueryable<TEntity> Index()
        {
            return _service.Index();
        }

        /// <summary>
        /// Show the entity record by id
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Show(int id)
        {
            var entity = await _service.Show(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        /// <summary>
        /// Store the submitted record
        /// </summary>
        /// <param name="entity">Entity sent</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TEntity>> Store(TEntity entity)
        {
            await _service.Store(entity);
            return CreatedAtAction("Show", new { id = entity.Id }, entity);
        }

        /// <summary>
        /// Update the entity record with the new content
        /// </summary>
        /// <param name="id">entity id</param>
        /// <param name="entity">Entity sent</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _service.Update(id, entity);
            return NoContent();
        }

        /// <summary>
        /// Destroy the entity record
        /// </summary>
        /// <param name="id">entity id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            var entity = await _service.Show(id);
            if (entity == null)
            {
                return NotFound();
            }
            await _service.Destroy(id);
            return NoContent();
        }
    }
}
