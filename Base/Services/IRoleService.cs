using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Models;

namespace Base.Services
{
    public interface IRoleService
    {
        Task<Role> FindById(int id);
        IQueryable<Role> FindAll();
        Task<Role> Update(int id,Role role);
        Task Delete(int id);
        Task<Role> Create(Role role);
    }
}
