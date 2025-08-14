
/// <summary>
/// Summary description for Class1
/// </summary>
using Assignment_6.Data;
using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Assignment_6.DTO;
using Assignment_6.Models;
namespace Assignment_6.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connStr;
        public UserRepository(IConfiguration config)
        {
            _config = config;
            _connStr = _config.GetConnectionString("DefaultConnection");
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("SELECT UserID, RoleID, Username, PasswordHash FROM Users WHERE Username = @Username", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            if (!reader.HasRows) return null;
            await reader.ReadAsync();
            return new User
            {
                UserID = reader.GetInt32(0),
                RoleID = reader.GetInt32(1),
                Username = reader.GetString(2),
                PasswordHash = reader.GetString(3)
            };
        }

        public async Task<int> CreateUserAsync(string username, string passwordHash, int roleId)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("INSERT INTO Users (RoleID, Username, PasswordHash) VALUES (@RoleID, @Username, @PasswordHash); SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@RoleID", roleId);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
            await conn.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }
    }
}
