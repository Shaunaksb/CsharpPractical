using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Initialize the Dictionary (Key = RollNo, Value = Name)
        Dictionary<int, string> students = new Dictionary<int, string>
        {
            { 101, "Alice" },
            { 102, "Bob" },
            { 103, "Charlie" }
        };

        // --- SEARCH OPERATION ---
        int searchId = 102;
        if (students.ContainsKey(searchId))
        {
            Console.WriteLine($"Search: Found Roll No {searchId}. Name: {students[searchId]}");
        }
        else
        {
            Console.WriteLine($"Search: Roll No {searchId} not found.");
        }

        // --- UPDATE OPERATION ---
        int updateId = 101;
        if (students.ContainsKey(updateId))
        {
            students[updateId] = "Alice Johnson"; // Updates the value for the existing key
            Console.WriteLine($"Update: Roll No {updateId} updated to {students[updateId]}");
        }

        // --- DELETE OPERATION ---
        int deleteId = 103;
        if (students.Remove(deleteId))
        {
            Console.WriteLine($"Delete: Roll No {deleteId} has been removed.");
        }

        // --- DISPLAY REMAINING RECORDS ---
        Console.WriteLine("\n--- Current Student List ---");
        foreach (var student in students)
        {
            Console.WriteLine($"Roll No: {student.Key}, Name: {student.Value}");
        }
    }
}