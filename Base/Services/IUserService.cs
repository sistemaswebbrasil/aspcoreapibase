using System.Threading.Tasks;
using Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace Base.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> FindByEmail(string email);

        Task<User> FindByUsername(string username);
    }
}
