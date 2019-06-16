using Base.Models;
namespace Base.Services
{

    public interface IAuthServices
    {
        User Signup(User user);
        AuthUser Authenticate(TokenRequest tokenRequest);
    }
}
