using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new DatabaseContext())
        {
            context.Database.EnsureCreated();
            Console.WriteLine("Users in DB before adding: ");
            context.Users.ToList().ForEach(u => Console.WriteLine($"Name: {u.Name}, Password: {u.Password}"));
            
            //context.Add<DatabaseUser>(new DatabaseUser()
            //{
            //    Id = 6,
            //    Name = "user",
            //    Password = "password",
            //    Roles = UserRolesEnum.STUDENT,
            //    Expires = DateTime.Now.AddYears(1),
            //    FacultyNumber = "F12346", 
            //    Email = "user@example.com" 
            //});

            context.SaveChanges();

            Console.WriteLine("username:");
            string inputName = Console.ReadLine();

            Console.WriteLine("password:");
            string inputPassword = Console.ReadLine();

            var user = context.Users
                              .FirstOrDefault(u => u.Name == inputName && u.Password == inputPassword);

            if (user != null)
            {
                Console.WriteLine("valid user");
            }
            else
            {
                Console.WriteLine("invalid user");
            }
        }
    }
}
