using Base.Models;
using System.Threading.Tasks;

namespace Base.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByEmail(string email);
        Task<User> FindByUsername(string username);
    }
}
