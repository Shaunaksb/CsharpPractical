using System;
using Microsoft.Data.SqlClient; // Ensure this NuGet package is installed

class Program
{
    // The string should ONLY contain the Server, Database, and Credentials
    static string connString = @"Data Source=DESKTOP-CU1LQ93\SQLEXPRESS;Initial Catalog=CollegeDB;Persist Security Info=True;User ID=sa;Password=root;Encrypt=False;TrustServerCertificate=True;";
    static void Main()
    {
        // 1. Insert a Record
        InsertStudent(101, "Alice", 85);
        InsertStudent(102, "Bob", 78);

        // 2. Display All Records
        DisplayStudents();

        // 3. Delete a Record
        DeleteStudent(102);

        // 4. Display again to verify deletion
        DisplayStudents();
    }

    static void InsertStudent(int id, string name, int marks)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "INSERT INTO Student (StudentID, Name, Marks) VALUES (@id, @name, @marks)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@marks", marks);

            conn.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Inserted: {name}");
        }
    }

    static void DisplayStudents()
    {
        Console.WriteLine("\n--- Student Records ---");
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["StudentID"]} | Name: {reader["Name"]} | Marks: {reader["Marks"]}");
                }
            }
        }
    }

    static void DeleteStudent(int id)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string query = "DELETE FROM Student WHERE StudentID = @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0) Console.WriteLine($"\nDeleted Student with ID: {id}");
        }
    }
}