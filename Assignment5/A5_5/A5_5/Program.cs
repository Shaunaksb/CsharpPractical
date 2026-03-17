using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // a. Accept string and find its length
        // Func<InputType, ReturnType>
        Func<string, int> getLength = s => s.Length;

        // b. Converts a string to uppercase
        Func<string, string> toUpper = s => s.ToUpper();

        // c. Add two integers
        // Func<Input1, Input2, ReturnType>
        Func<int, int, int> add = (x, y) => x + y;

        // d. Filter even numbers from a list
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // We use a lambda inside the .Where method
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

        // --- Testing the results ---
        string testStr = "Hello world";

        Console.WriteLine($"String: '{testStr}'");
        Console.WriteLine($"a. Length: {getLength(testStr)}");
        Console.WriteLine($"b. Uppercase: {toUpper(testStr)}");
        Console.WriteLine($"c. Sum of 10 + 20: {add(10, 20)}");
        Console.WriteLine($"d. Even numbers: {string.Join(", ", evenNumbers)}");
    }
}