using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    static class UserHelper
    {
        public static string ToUserString(this User user)
        {
            return $"ID: {user.Id}, Name: {user.Name}, FacultyNumber: {user.FacultyNumber}, Email: {user.Email}, Role: {user.Roles}, Expires: {user.Expires}";
        }
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            string? emptyField = string.IsNullOrWhiteSpace(name) ? "name" : string.IsNullOrWhiteSpace(password) ? "password" : null;
            if (emptyField != null) throw new ArgumentException($"The {emptyField} cannot be empty");

            return userData.ValidateUser(name, password);
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        }
    }
}
