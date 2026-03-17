using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static string filePath = "records.txt";

    static void Main()
    {
        // Ensure the file exists before we start
        if (!File.Exists(filePath)) { File.Create(filePath).Close(); }

        while (true)
        {
            Console.WriteLine("\n--- STUDENT RECORD SYSTEM ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Delete Student Record");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddStudent(); break;
                case "2": ViewAll(); break;
                case "3": SearchById(); break;
                case "4": DeleteRecord(); break;
                case "5": Environment.Exit(0); break;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Marks: ");
        string marks = Console.ReadLine();

        // Format: ID,Name,Marks
        string record = $"{id},{name},{marks}";
        File.AppendAllLines(filePath, new[] { record });
        Console.WriteLine("Record added successfully!");
    }

    static void ViewAll()
    {
        Console.WriteLine("\nID\tName\tMarks");
        Console.WriteLine("-------------------------");
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] data = line.Split(',');
            Console.WriteLine($"{data[0]}\t{data[1]}\t{data[2]}");
        }
    }

    static void SearchById()
    {
        Console.Write("Enter ID to search: ");
        string searchId = Console.ReadLine();
        var record = File.ReadAllLines(filePath)
                         .FirstOrDefault(l => l.StartsWith(searchId + ","));

        if (record != null)
        {
            string[] data = record.Split(',');
            Console.WriteLine($"Found: Name: {data[1]}, Marks: {data[2]}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DeleteRecord()
    {
        Console.Write("Enter ID to delete: ");
        string deleteId = Console.ReadLine();

        // Load all records, filter out the one to delete, and rewrite the file
        var lines = File.ReadAllLines(filePath).ToList();
        int initialCount = lines.Count;
        lines.RemoveAll(l => l.StartsWith(deleteId + ","));

        if (lines.Count < initialCount)
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Record deleted.");
        }
        else
        {
            Console.WriteLine("ID not found.");
        }
    }
}