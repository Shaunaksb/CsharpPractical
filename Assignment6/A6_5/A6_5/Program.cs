using System;
using System.IO;

class Program
{
    static string filePath = "employees.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- EMPLOYEE SYSTEM ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search by ID");
            Console.WriteLine("3. Exit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            if (choice == "1") AddEmployee();
            else if (choice == "2") SearchEmployee();
            else if (choice == "3") break;
        }
    }

    static void AddEmployee()
    {
        using (StreamWriter sw = File.AppendText(filePath))
        {
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            // Store as: ID|Name|Department
            sw.WriteLine($"{id}|{name}|{dept}");
            Console.WriteLine("Record saved!");
        }
    }

    static void SearchEmployee()
    {
        Console.Write("Enter ID to search: ");
        string searchId = Console.ReadLine();
        bool found = false;

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No records found.");
            return;
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] details = line.Split('|');
                if (details[0] == searchId)
                {
                    Console.WriteLine("\n--- Record Found ---");
                    Console.WriteLine($"ID: {details[0]}\nName: {details[1]}\nDept: {details[2]}");
                    found = true;
                    break;
                }
            }
        }

        if (!found) Console.WriteLine("Employee not found.");
    }
}