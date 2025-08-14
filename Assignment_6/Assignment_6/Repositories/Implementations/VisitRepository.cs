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
    public class VisitRepository : IVisitRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connStr;
        public VisitRepository(IConfiguration config)
        {
            _config = config;
            _connStr = _config.GetConnectionString("DefaultConnection");
        }

        public async Task AddVisitAsync(AddVisitRequest req)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("stp_AddVisit", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@PatientName", req.PatientName);
            cmd.Parameters.AddWithValue("@VisitTypeName", req.VisitTypeName);
            cmd.Parameters.AddWithValue("@DoctorName", req.DoctorName);
            cmd.Parameters.AddWithValue("@Description", req.Description ?? string.Empty);
            cmd.Parameters.AddWithValue("@DurationMinutes", req.DurationMinutes);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UpdateVisitAsync(UpdateVisitRequest req)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("stp_UpdateVisit", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@PatientName", req.PatientName);
            cmd.Parameters.AddWithValue("@VisitTypeName", req.VisitTypeName);
            cmd.Parameters.AddWithValue("@DoctorName", req.DoctorName);
            cmd.Parameters.AddWithValue("@Description", req.Description ?? string.Empty);
            cmd.Parameters.AddWithValue("@DurationMinutes", req.DurationMinutes);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteVisitAsync(DeleteVisitRequest req)
        {
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("stp_DeleteVisit", conn) { CommandType = CommandType.StoredProcedure };

            cmd.Parameters.AddWithValue("@PatientName", req.PatientName);
            cmd.Parameters.AddWithValue("@VisitTypeName", req.VisitTypeName);
            cmd.Parameters.AddWithValue("@DoctorName", req.DoctorName);
            cmd.Parameters.AddWithValue("@DurationMinutes", req.DurationMinutes);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<VisitDto>> SearchByPatientAsync(string patientName)
        {
            var list = new List<VisitDto>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("stp_SearchByPatient", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@PatientName", patientName);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new VisitDto
                {
                    VisitId = reader.GetInt32(reader.GetOrdinal("VisitID")),
                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                    DoctorName = reader.GetString(reader.GetOrdinal("DoctorName")),
                    VisitType = reader.GetString(reader.GetOrdinal("VisitType")),
                    VisitDate = reader.GetDateTime(reader.GetOrdinal("VisitDate")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    DurationMinutes = reader.GetInt32(reader.GetOrdinal("DurationMinutes")),
                    Fee = reader.GetDecimal(reader.GetOrdinal("Fee"))
                });
            }
            return list;
        }

        public async Task<IEnumerable<VisitDto>> SearchByDoctorAsync(string doctorName)
        {
            var list = new List<VisitDto>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("stp_SearchByDoctor", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DoctorName", doctorName);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new VisitDto
                {
                    VisitId = reader.GetInt32(reader.GetOrdinal("VisitID")),
                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                    DoctorName = reader.GetString(reader.GetOrdinal("DoctorName")),
                    VisitType = reader.GetString(reader.GetOrdinal("VisitType")),
                    VisitDate = reader.GetDateTime(reader.GetOrdinal("VisitDate")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    DurationMinutes = reader.GetInt32(reader.GetOrdinal("DurationMinutes")),
                    Fee = reader.GetDecimal(reader.GetOrdinal("Fee"))
                });
            }
            return list;
        }

        public async Task<IEnumerable<VisitDto>> SearchByVisitTypeAsync(string visitTypeName)
        {
            var list = new List<VisitDto>();
            using var conn = new SqlConnection(_connStr);
            using var cmd = new SqlCommand("stp_SearchByVisitType", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@VisitTypeName", visitTypeName);

            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new VisitDto
                {
                    VisitId = reader.GetInt32(reader.GetOrdinal("VisitID")),
                    PatientName = reader.GetString(reader.GetOrdinal("PatientName")),
                    DoctorName = reader.GetString(reader.GetOrdinal("DoctorName")),
                    VisitType = reader.GetString(reader.GetOrdinal("VisitType")),
                    VisitDate = reader.GetDateTime(reader.GetOrdinal("VisitDate")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    DurationMinutes = reader.GetInt32(reader.GetOrdinal("DurationMinutes")),
                    Fee = reader.GetDecimal(reader.GetOrdinal("Fee"))
                });
            }
            return list;
        }
    }
}
