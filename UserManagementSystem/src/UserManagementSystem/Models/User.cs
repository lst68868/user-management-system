using System;
namespace UserManagementSystem.Models
{
    public class User
    {
        public User(string username, string name, string email)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
