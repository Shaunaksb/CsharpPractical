using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Initialize a list of strings
        List<string> fruits = new List<string> { "Banana", "Apple", "Elderberry", "Cherry", "Date" };

        Console.WriteLine("Original List: " + string.Join(", ", fruits));

        // 2. Sort the list alphabetically (A-Z)
        fruits.Sort();
        Console.WriteLine("Sorted List:   " + string.Join(", ", fruits));

        // 3. Reverse the current order (Z-A if previously sorted)
        fruits.Reverse();
        Console.WriteLine("Reversed List: " + string.Join(", ", fruits));
    }
}