using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;
        
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string? Login(LoginRequest request)
        {
            // Simple hardcoded validation for demo
            if (request.Username == "admin" && request.Password == "admin123")
            {
                return GenerateJwtToken(request.Username);
            }
            return null;
        }
        
        private string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Sub, username)
            };
            
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
