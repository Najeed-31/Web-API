
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
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connStr;
        public PatientRepository(IConfiguration config)
        {
            _config = config;
            _connStr = _config.GetConnectionString("DefaultConnection");
        }
        public async Task<int?> GetPatientIdByNameAsync(string fullName)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("SELECT PatientID FROM Patients WHERE FullName = @FullName", conn);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            await conn.OpenAsync();
            var res = await cmd.ExecuteScalarAsync();
            if (res == null || res == DBNull.Value) return null;
            return Convert.ToInt32(res);
        }

        public async Task<int> CreatePatientAsync(string fullName)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("INSERT INTO Patients (FullName) VALUES (@FullName); SELECT SCOPE_IDENTITY();", conn);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            await conn.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }
    }
}