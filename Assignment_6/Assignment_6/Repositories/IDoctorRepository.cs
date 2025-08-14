using System;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Class1
/// </summary>
using Assignment_6.Models;
namespace Assignment_6.Repositories
{
    public interface IDoctorRepository
    {
        Task<int?> GetDoctorIdByNameAsync(string fullName);
        Task<int> CreateDoctorAsync(string fullName);
    }
}