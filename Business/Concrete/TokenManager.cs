using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class TokenManager
    {
        private readonly IConfiguration _config;
        private readonly UserManager<T110User> _manager;
        public TokenManager(IConfiguration config, UserManager<T110User> manager)
        {
            _config = config;
            _manager = manager;
        }
        public async Task<string> GenerateToken(T110User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("FullName",user.FirstName+" "+ user.LastName)
            };
            var roles =await _manager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
             issuer:null,
             audience:null,
             claims,
             expires: DateTime.UtcNow.AddMinutes(10),
             signingCredentials: creds
             );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
