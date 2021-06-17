using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Quickorders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quickorders.Domain.Services
{
    class EncryptService
    {
        private readonly IConfiguration _configuration;

        public EncryptService(IConfiguration config)
        {
            _configuration = config;
        }

        public string GenerateUserToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
               
                new Claim("isOwner", user.IsOwner?"Yes":"Nop"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds
                );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token).ToString();
            
            return tokenString;
        }
    }
}
