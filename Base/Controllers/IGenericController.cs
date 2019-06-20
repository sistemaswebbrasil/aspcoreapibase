using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers
{
    public interface IGenericController<TEntity>
    {
        IQueryable<TEntity> Index();

        Task<ActionResult<TEntity>> Show(int id);

        Task<ActionResult<TEntity>> Store(TEntity entity);

        Task<IActionResult> Update(int id, TEntity entity);

        Task<IActionResult> Destroy(int id);

    }
}
