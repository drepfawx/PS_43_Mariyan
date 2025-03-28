using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using Welcome.Others;
using System.Runtime.InteropServices;
using WelcomeExtended.Data;
using System.Xml.Linq;
using WelcomeExtended.Helpers;

namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserData userData = new UserData();

                userData.AddUser(new User() { Name = "student", Password = "123", Roles = UserRolesEnum.STUDENT, FacultyNumber = "F12345", Email = "student@example.com", Expires = new DateTime(2025, 6, 15) });
                userData.AddUser(new User() { Name = "Student2", Password = "123", Roles = UserRolesEnum.STUDENT, FacultyNumber = "F67890", Email = "student2@example.com", Expires = new DateTime(2025, 12, 10) });
                userData.AddUser(new User() { Name = "Teacher", Password = "1234", Roles = UserRolesEnum.PROFESSOR, FacultyNumber = "P11223", Email = "teacher@example.com", Expires = new DateTime(2025, 8, 1) });
                userData.AddUser(new User() { Name = "Admin", Password = "12345", Roles = UserRolesEnum.ADMIN, FacultyNumber = "A99887", Email = "admin@example.com", Expires = new DateTime(2025, 3, 25) });

                Console.WriteLine("name: ");
                string name = Console.ReadLine();
                Console.WriteLine("password: ");
                string password = Console.ReadLine();

                bool isValid = userData.ValidateCredentials(name, password);

                if (isValid)
                {
                    User user = userData.GetUser(name, password);
                    if (user != null)
                    {
                        Console.WriteLine(user.ToUserString());
                    }
                    else
                    {
                        throw new Exception("user not found");
                    }
                }
                else
                {
                    Console.WriteLine("invalid credentials.");
                }
            }
            catch (Exception e)
            {
                var log = new ActionOnError(Others.Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}