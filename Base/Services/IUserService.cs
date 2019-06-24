using Base.Models;
using System.Threading.Tasks;

namespace Base.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<User> FindByEmail(string email);

        Task<User> FindByUsername(string username);
    }
}
