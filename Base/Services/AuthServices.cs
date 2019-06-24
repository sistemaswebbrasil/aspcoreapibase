using Base.Helpers;
using Base.Models;
//using Base.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly AppSetting _appSettings;
        private readonly IUserService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest _request;

        public AuthServices(IOptions<AppSetting> appSettings, IUserService service, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
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
                Subject = new ClaimsIdentity(new Claim[]
                {
                  new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                  new Claim(ClaimTypes.Name, user.Username),
                  new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AuthUser authUser = new AuthUser(user.Id, user.Username, user.Email, tokenHandler.WriteToken(token));

            return authUser;
        }

        public async Task<AuthUser> profile()
        {
            var claimsIdentity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1];
            var user = await _service.Show(Convert.ToInt32(userId) );
            if (user == null)
            {
                return null;
            }
            return new AuthUser(user.Id,user.Username,user.Email, token);
        }

        public async Task<User> Signup(User userForm)
        {
            userForm.Password = Secret.GenerateHash(userForm.Password);
            await _service.Store(userForm);
            return userForm;
        }
    }
}
