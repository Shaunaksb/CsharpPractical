using System;
using Microsoft.Data.SqlClient;

class Program
{
    // Use your specific connection string with the correct Initial Catalog
    static string connString = @"Data Source=DESKTOP-CU1LQ93\SQLEXPRESS;Initial Catalog=CollegeDB;Persist Security Info=True;User ID=sa;Password=root;Encrypt=False;TrustServerCertificate=True;";

    static void Main()
    {
        Console.WriteLine("--- SYSTEM LOGIN ---");

        Console.Write("Username: ");
        string inputUser = Console.ReadLine();

        Console.Write("Password: ");
        string inputPass = Console.ReadLine();

        if (ValidateLogin(inputUser, inputPass))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLogin Successful! Welcome to the system.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nInvalid Username or Password.");
        }

        Console.ResetColor();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static bool ValidateLogin(string user, string pass)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            // We count how many users match BOTH username and password
            string query = "SELECT COUNT(1) FROM Users WHERE Username = @u AND Password = @p";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@u", user);
            cmd.Parameters.AddWithValue("@p", pass);

            try
            {
                conn.Open();
                // ExecuteScalar returns the first column of the first row (the Count)
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count == 1; // If 1 match found, return true
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
                return false;
            }
        }
    }
}