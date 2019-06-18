using System.Threading.Tasks;
using Base.Models;

namespace Base.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindByEmail(string email);
        Task<User> FindByUsername(string username);
    }
}
