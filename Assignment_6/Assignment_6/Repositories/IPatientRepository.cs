
using System;
using System.Threading.Tasks;
using Assignment_6.Models;
namespace Assignment_6.Repositories
{
    public interface IPatientRepository
    {
        Task<int?> GetPatientIdByNameAsync(string fullName);
        Task<int> CreatePatientAsync(string fullName);
    }
}
