using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string to reverse: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("The string is empty.");
            return;
        }

        // 1. Create a Stack of characters
        Stack<char> charStack = new Stack<char>();

        // 2. Push each character of the string onto the stack
        foreach (char c in input)
        {
            charStack.Push(c);
        }

        // 3. Pop characters from the stack to build the reversed string
        string reversed = "";
        while (charStack.Count > 0)
        {
            reversed += charStack.Pop();
        }

        Console.WriteLine($"Original: {input}");
        Console.WriteLine($"Reversed: {reversed}");
    }
}