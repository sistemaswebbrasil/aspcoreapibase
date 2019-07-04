using Base.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace Base.Services
{

    public interface IAuthServices
    {
        Task<User> Signup(User user);
        Task<AuthUser> Authenticate(TokenRequest tokenRequest);
        Task<AuthUser> profile();
        Task<bool> UsernameAvailable(string username);
        Task<bool> EmailAvailable(string email);
    }
}
