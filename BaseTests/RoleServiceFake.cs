using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Models;
using Base.Services;

namespace BaseTests
{
    public class RoleServiceFake : IRoleService
    {
        private readonly IQueryable<Role> _roles;

        public RoleServiceFake()
        {
            _roles =
                (new List<Role> {
                    new Role() { Id = 1,Description="Teste1"},
                    new Role() { Id = 2,Description="Teste2"},
                    new Role() { Id = 3,Description="Teste3"},
                    new Role() { Id = 4,Description="Teste4"},
                    new Role() { Id = 5,Description="Teste5"}
                }).AsQueryable();
        }

        public async Task<Role> Create(Role role)
        {
            await Task.Delay(1000);
            _roles.Append(role);
            return role;
        }

        public async Task Delete(int id)
        {
            await Task.Delay(1000);
            _roles.Where(a => a.Id != id);
        }

        public IQueryable<Role> FindAll()
        {
            return _roles;
        }

        public async Task<Role> FindById(int id)
        {
            await Task.Delay(1);
            return _roles.Where(a => a.Id == id)
                    .FirstOrDefault();
        }

        public Task<Role> Update(int id, Role role)
        {
            throw new System.NotImplementedException();
        }
    }
}
