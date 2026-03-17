using System;
using System.Linq; // Included for a shorter alternative

class Program
{
    static void Main()
    {
        // 1. Initialize an integer array
        int[] numbers = { 12, 45, 7, 33, 98, 2, 56 };

        // 2. Variables to store our statistics
        int sum = 0;
        int max = numbers[0]; // Start by assuming the first element is the largest
        int min = numbers[0]; // Start by assuming the first element is the smallest

        // 3. Loop through the array once to calculate values
        foreach (int num in numbers)
        {
            sum += num;

            if (num > max)
                max = num;

            if (num < min)
                min = num;
        }

        // 4. Calculate average (cast to double to maintain decimal precision)
        double average = (double)sum / numbers.Length;

        // 5. Display results
        Console.WriteLine("Array: " + string.Join(", ", numbers));
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Sum:     {sum}");
        Console.WriteLine($"Average: {average:F2}"); // F2 formats to 2 decimal places
        Console.WriteLine($"Maximum: {max}");
        Console.WriteLine($"Minimum: {min}");
    }
}