using System;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Class1
/// </summary>
using Assignment_6.Models;
namespace Assignment_6.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task<int> CreateUserAsync(string username, string passwordHash, int roleId);
    }
}