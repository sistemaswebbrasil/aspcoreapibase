using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Models;
using Base.Repositories;

namespace Base.Services
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> _repository;
        public RoleService(IGenericRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<Role> Create(Role role)
        {
            await _repository.Create(role);
            return role;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public IQueryable<Role> FindAll()
        {
            return _repository.GetAll();
        }

        public async Task<Role> FindById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Role> Update(int id, Role role)
        {
            await _repository.Update(id, role);
            return role;
        }
    }
}
