using System;
using Microsoft.Data.SqlClient;

class Program
{
    // Using your specific connection string
    static string connString = @"Data Source=DESKTOP-CU1LQ93\SQLEXPRESS;Initial Catalog=CollegeDB;Persist Security Info=True;User ID=sa;Password=root;Encrypt=False;TrustServerCertificate=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- INVENTORY MANAGEMENT ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Quantity");
            Console.WriteLine("3. Display All Products");
            Console.WriteLine("4. Exit");
            Console.Write("Select Option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddProduct(); break;
                case "2": UpdateQuantity(); break;
                case "3": DisplayProducts(); break;
                case "4": return;
                default: Console.WriteLine("Invalid choice!"); break;
            }
        }
    }

    static void AddProduct()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Initial Quantity: ");
        int qty = int.Parse(Console.ReadLine());
        Console.Write("Enter Price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sql = "INSERT INTO Products (ProductName, Quantity, Price) VALUES (@name, @qty, @price)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@price", price);

            conn.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Product added successfully!");
        }
    }

    static void UpdateQuantity()
    {
        Console.Write("Enter Product ID to update: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter New Total Quantity: ");
        int newQty = int.Parse(Console.ReadLine());

        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sql = "UPDATE Products SET Quantity = @qty WHERE ProductID = @id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@qty", newQty);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0) Console.WriteLine("Stock updated!");
            else Console.WriteLine("Product ID not found.");
        }
    }

    static void DisplayProducts()
    {
        Console.WriteLine("\nID\tName\t\tQty\tPrice");
        Console.WriteLine("---------------------------------------------");
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sql = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]}\t{reader[1].ToString().PadRight(15)}\t{reader[2]}\t{reader[3]:C}");
            }
        }
    }
}