using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DepartmentsEmployeesAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        private readonly Dictionary<string, (string Password, string Role)> _users =
            new()
            {
                { "admin", ("admin123", "Admin") },
                { "user", ("user123", "User") }
            };

        public AuthService(IConfiguration config) => _config = config;

        public Task<string?> AuthenticateAsync(string username, string password)
        {
            if (!_users.TryGetValue(username, out var entry) || entry.Password != password)
                return Task.FromResult<string?>(null);

            var role = entry.Role;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_config["Jwt:ExpireMinutes"] ?? "60")),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult<string?>(tokenString);
        }
    }
}
