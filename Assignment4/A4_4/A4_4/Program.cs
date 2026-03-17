using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Create a list of integers
        List<int> numbers = new List<int> { 11, 22, 33, 44, 55, 66, 77, 88, 99 };

        int evenCount = 0;
        int oddCount = 0;

        // 2. Iterate through the list
        foreach (int num in numbers)
        {
            // A number is even if (number % 2) is 0
            if (num % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }

        // 3. Display the results
        Console.WriteLine("List: " + string.Join(", ", numbers));
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Even numbers found: {evenCount}");
        Console.WriteLine($"Odd numbers found:  {oddCount}");
    }
}