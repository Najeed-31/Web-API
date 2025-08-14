using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Assignment_6.DTO
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
    }
}