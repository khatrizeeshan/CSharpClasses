using System;
using System.Data.SqlClient;

namespace ConsoleDBApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Class1Db;Trusted_Connection=True;MultipleActiveResultSets=true";
                var connection = new SqlConnection(connectionString);
                connection.Open();

                Console.WriteLine("Connetion succeed.");
                var query = "SELECT * FROM Users";
                var command = connection.CreateCommand();
                command.CommandText = query;
                var reader = command.ExecuteReader();
                Console.WriteLine("Reading records.");
                while (reader.Read()) {
                    Console.WriteLine($"Id: {reader["Id"]}");
                    Console.WriteLine($"Name: {reader["Name"]}");
                    Console.WriteLine($"Email: {reader["Email"]}");
                    Console.WriteLine($"Password: {reader["Password"]}");
                }
                reader.Close();

                Console.WriteLine("Press 'N' for adding new record:");
                Console.WriteLine("Press 'X' to exit:");
                var line = Console.ReadLine();
                while(line != "X")
                {
                    if (line == "N")
                    {
                        Console.WriteLine("Enter Id: ");
                        var id = Console.ReadLine();

                        Console.WriteLine("Enter Name: ");
                        var name = Console.ReadLine();

                        Console.WriteLine("Enter Email: ");
                        var email = Console.ReadLine();

                        Console.WriteLine("Enter Password: ");
                        var password = Console.ReadLine();

                        var insertCommandText = $"INSERT INTO Users (Id, Name, Email, Password) VALUES({id}, '{name}', '{email}', '{password}')";
                        Console.WriteLine(insertCommandText);
                        var insertCommand = connection.CreateCommand();
                        insertCommand.CommandText = insertCommandText;
                        var rows = insertCommand.ExecuteNonQuery();
                        Console.WriteLine($"Rows effected: {rows}");
                    }

                    line = Console.ReadLine();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
