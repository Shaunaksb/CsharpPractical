using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Create and populate a list
        List<int> numbers = new List<int> { 10, 25, 42, 55, 70, 88, 101 };

        Console.WriteLine("List contents: " + string.Join(", ", numbers));
        Console.Write("Enter the number you want to search for: ");

        if (int.TryParse(Console.ReadLine(), out int target))
        {
            // Method A: Using the built-in IndexOf method
            int index = numbers.IndexOf(target);

            // Method B: Manual Linear Search (Alternative Logic)
            // int index = LinearSearch(numbers, target);

            if (index != -1)
            {
                Console.WriteLine($"Element {target} found at index: {index}");
            }
            else
            {
                Console.WriteLine($"Element {target} was not found in the list.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid integer.");
        }
    }

    // Manual implementation of a search
    static int LinearSearch(List<int> list, int target)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == target)
            {
                return i; // Return the current index if found
            }
        }
        return -1; // Return -1 if the loop finishes without finding the target
    }
}