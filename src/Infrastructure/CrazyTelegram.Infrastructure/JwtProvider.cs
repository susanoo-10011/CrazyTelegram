using CrazyTelegram.Application.Interfaces;
using CrazyTelegram.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrazyTelegram.Infrastructure
{




    public class JwtProvider : IJWTProvider
    {

        private readonly string _jwtkey;

        public JwtProvider(IConfiguration configuration)
        {
            _jwtkey = configuration["JwtSettings:Key"];
        }

        public string GetSetting()
        {
            return _jwtkey;
        }





        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Login),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetSetting())); // Используем тот же ключ, что и в конфигурации
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Время жизни токена
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
