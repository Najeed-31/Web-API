using System;

/// <summary>
/// Summary description for Class1
/// </summary>
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Assignment_6.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace Assignment_6.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        // simple hash using SHA256 (for assignment/demonstration). In production use a stronger PBKDF2/Bcrypt/Argon2.
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public async Task<int> RegisterAsync(string username, string password, int roleId)
        {
            var existing = await _userRepo.GetByUsernameAsync(username);
            if (existing != null) throw new Exception("User already exists.");

            var hash = HashPassword(password);
            var id = await _userRepo.CreateUserAsync(username, hash, roleId);
            return id;
        }

        public async Task<string> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepo.GetByUsernameAsync(username);
            if (user == null) return null;

            var hash = HashPassword(password);
            if (user.PasswordHash != hash) return null;

            // create JWT token
            var jwtSection = _config.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSection["Key"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("userId", user.UserID.ToString()),
                // role claim not available in Users model in our simple schema; if RoleName needed, extend Users join.
                new Claim(ClaimTypes.Role, user.RoleID == 1 ? "Administrator" : "Receptionist")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSection["ExpiryMinutes"])),
                Issuer = jwtSection["Issuer"],
                Audience = jwtSection["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}