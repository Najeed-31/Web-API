using System;

/// <summary>
/// Summary description for Class1
/// </summary>
using Assignment_6.Models;

namespace Assignment_6.Services
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
        Task<int> RegisterAsync(string username, string password, int roleId);
    }
}