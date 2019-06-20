using System.Linq;
using System.Threading.Tasks;
using Base.Models;
using Base.Repositories;

namespace Base.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : class, ITrackable
    {
        private readonly IGenericRepository<TEntity> _repository;


        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IQueryable<TEntity> Index()
        {
            return _repository.GetAll();
        }

        public async Task<TEntity> Show(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<TEntity> Store(TEntity entity)
        {
            await _repository.Create(entity);
            return entity;
        }

        public async Task Update(int id, TEntity entity)
        {
            await _repository.Update(id, entity);
        }

        public async Task Destroy(int id)
        {
            await _repository.Delete(id);
        }

    }
}
