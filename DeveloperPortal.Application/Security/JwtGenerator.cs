using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.Application.Security
{
    public class JwtGenerator
    {
        private readonly IConfiguration _config;
        private readonly byte[] _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expires;

        public JwtGenerator(IConfiguration config)
        {
            _config = config;
            _issuer = _config["JwtSettings:Issuer"];
            _audience = _config["JwtSettings:Audience"];
            _expires = int.Parse(_config["JwtSettings:ExpiresInMinutes"]);
            _key = Convert.FromBase64String(_config["JwtSettings:Secret"]);
        }

        public string CreateToken(int userId, string email, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email)
        };
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(_key),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expires),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
