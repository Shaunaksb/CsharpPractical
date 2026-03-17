using System;
using Microsoft.Data.SqlClient; // Ensure NuGet package is installed

class Program
{
    // Connection string for your specific SQLEXPRESS instance
    static string connString = @"Data Source=DESKTOP-CU1LQ93\SQLEXPRESS;Initial Catalog=CollegeDB;Persist Security Info=True;User ID=sa;Password=root;Encrypt=False;TrustServerCertificate=True;";

    static void Main()
    {
        // 1. Get User Input
        Console.WriteLine("--- Enter Employee Details ---");

        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        // 2. Insert into SQL Server
        InsertEmployee(id, name, salary);

        // 3. Display All Records
        DisplayEmployees();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void InsertEmployee(int id, string name, decimal salary)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            // Use Parameters to prevent SQL Injection
            string query = "INSERT INTO Employee (EmpID, Name, Salary) VALUES (@id, @name, @salary)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@salary", salary);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\nSuccess: Record inserted into database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError during Insert: " + ex.Message);
            }
        }
    }

    static void DisplayEmployees()
    {
        Console.WriteLine("\n--- Employee List from SQL Server ---");
        Console.WriteLine("ID\tName\t\tSalary");
        Console.WriteLine("--------------------------------------");

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "SELECT * FROM Employee";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Accessing data by column name
                        Console.WriteLine($"{reader["EmpID"]}\t{reader["Name"].ToString().PadRight(15)}\t{reader["Salary"]:C}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during Select: " + ex.Message);
            }
        }
    }
}