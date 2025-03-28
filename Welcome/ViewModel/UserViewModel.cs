using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace Welcome.ViewModel
{
    public class UserViewModel
    {
        private User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string Name { get => _user.Name; set => _user.Name = value; }
        public string FacultyNumber { get => _user.FacultyNumber; set => _user.FacultyNumber = value; }
        public string Email { get => _user.Email; set => _user.Email = value; }
        public string Password { get => _user.Password; set => _user.Password = value; }
        public UserRolesEnum Role { get => _user.Roles; set => _user.Roles = value; }
    }
}
