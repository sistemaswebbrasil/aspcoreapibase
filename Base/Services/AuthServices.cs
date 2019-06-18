using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Base.Helpers;
using Base.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Base.Services
{
    public class AuthServices : IAuthServices
    {

        private readonly AppSetting _appSettings;
        private readonly AppDbContext _context;

        public AuthServices(IOptions<AppSetting> appSettings, AppDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthUser Authenticate(TokenRequest tokenRequest)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == tokenRequest.Email);
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

        public User Signup(User userForm)
        {
            userForm.Password = Secret.GenerateHash(userForm.Password);
            _context.Users.Add(userForm);
            _context.SaveChanges();
            return userForm;
        }
    }
}
