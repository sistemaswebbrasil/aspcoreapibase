using System.Linq;
using System.Threading.Tasks;

namespace Base.Services
{
    public interface IGenericService<TEntity>
    {
        IQueryable<TEntity> Index();

        Task<TEntity> Show(int id);

        Task<TEntity> Store(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Destroy(int id);
    }
}
