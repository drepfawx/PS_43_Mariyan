using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private int id;
        private DateTime expires;
        private string name;
        private string password;
        private string facultyNumber;
        private string email;
        private UserRolesEnum roles;

        public User() { }
        public User(string name, string password, string facultyNumber, string email, UserRolesEnum roles, int id, DateTime expires)
        {
            this.name = name;
            this.password = Encrypt(password);
            this.facultyNumber = facultyNumber;
            this.email = email;
            this.roles = roles;
            this.id = id;
            this.expires = expires;
        }
        public int Id { get => id; set => id = value; }
        public DateTime Expires { get => expires; set => expires = value; }
        public string Name { get => name; set => name = value; }
        public string FacultyNumber { get => facultyNumber; set => facultyNumber = value; }
        public string Email { get => email; set => email = value; }
        public UserRolesEnum Roles { get => roles; set => roles = value; }

        public string Password
        {
            get => Decrypt(password);
            set => password = Encrypt(value);
        }

        private string Encrypt(string input) => Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        private string Decrypt(string input) => Encoding.UTF8.GetString(Convert.FromBase64String(input));
    }
}

