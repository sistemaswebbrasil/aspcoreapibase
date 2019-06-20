using System.Threading.Tasks;
using Base.Models;
namespace Base.Services
{

    public interface IAuthServices
    {
        Task<User> Signup(User user);
        Task<AuthUser> Authenticate(TokenRequest tokenRequest);
    }
}
