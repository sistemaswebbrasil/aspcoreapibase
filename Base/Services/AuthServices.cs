using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Base.Helpers;
using Base.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Base.Services
{
    public class AuthServices : IAuthServices
    {

        private readonly AppSetting _appSettings;
        private readonly IUserService _service;

        public AuthServices(IOptions<AppSetting> appSettings, IUserService service)
        {
            _appSettings = appSettings.Value;
            _service = service;
        }

        public async Task<AuthUser> Authenticate(TokenRequest tokenRequest)
        {
            var user = await _service.FindByEmail(tokenRequest.Email);
            if (user == null || Secret.Validate(tokenRequest.Password, user.Password) == false)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim (ClaimTypes.Name, user.Id.ToString ())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            AuthUser authUser = new AuthUser(user.Id, user.Username, user.Email, tokenHandler.WriteToken(token));

            return authUser;
        }

        public async Task<User> Signup(User userForm)
        {
            userForm.Password = Secret.GenerateHash(userForm.Password);
            await _service.Store(userForm);
            return userForm;
        }
    }
}
