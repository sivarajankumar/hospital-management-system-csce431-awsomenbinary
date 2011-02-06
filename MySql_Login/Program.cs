using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MySql_Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionstring = @"Data Source"".\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Main.mdf;Integrated Security=true;User Instance=true";
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                connection.Open();
                Console.WriteLine("Connection obtained");
                Console.WriteLine("");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.Read();
            }
            Console.WriteLine("Username> ");
            string username = Console.ReadLine();
            Console.Write("Password> ");
            string password = Console.ReadLine();
            SqlCommand command = new SqlCommand("SELECT * FROM [users] WHERE Username=' " + username + " ' AND Password='" + password + "'", connection);
            SqlDataReader reader = null;
            reader = command .ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine("Welcome: " + reader["username"].ToString());
                Console.Read();

            }
            Console.WriteLine("User:" + username + " does not exist");
            
        }
    }
}
