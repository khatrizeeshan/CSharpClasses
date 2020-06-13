using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace ConsoleAppWithEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ClassDb1Context();
            foreach(var item in context.Users)
            {
                Console.WriteLine($"Id: {item.Id}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Email: {item.Email}");
                Console.WriteLine($"Password: {item.Password}");
            }

            var user = new User();
            Console.WriteLine("Enter Id: ");
            user.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name: ");
            user.Name = Console.ReadLine();

            Console.WriteLine("Enter Email: ");
            user.Email = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            user.Password = Console.ReadLine();

            context.Add(user);
            context.SaveChanges();
        }
    }

    class ClassDb1Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Class1Db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<User> Users { get; set; }
    }

    class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }

}
