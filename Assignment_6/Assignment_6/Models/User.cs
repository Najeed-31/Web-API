using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Assignment_6.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}