using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace DataLayer.Database
{
    class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();
            var user1 = new DatabaseUser() { Id = 1, Name = "John Doe", Password = "1234", Roles = UserRolesEnum.ADMIN, Expires = DateTime.Now.AddYears(10), FacultyNumber = "F12345", Email = "john.doe@example.com" };
            var user2 = new DatabaseUser() { Id = 2, Name = "Alice Smith", Password = "abcd1234", Roles = UserRolesEnum.STUDENT, Expires = DateTime.Now.AddYears(5), FacultyNumber = "F67890", Email = "alice.smith@example.com" };
            var user3 = new DatabaseUser() { Id = 3, Name = "Bob Johnson", Password = "qwerty5678", Roles = UserRolesEnum.PROFESSOR, Expires = DateTime.Now.AddYears(3), FacultyNumber = "P11223", Email = "bob.johnson@example.com" };
            var user4 = new DatabaseUser() { Id = 4, Name = "Charlie Brown", Password = "password2025", Roles = UserRolesEnum.STUDENT, Expires = DateTime.Now.AddYears(4), FacultyNumber = "F33445", Email = "charlie.brown@example.com" };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user1, user2, user3, user4);
        }

        public DbSet<DatabaseUser> Users { get; set; }


    }
}
