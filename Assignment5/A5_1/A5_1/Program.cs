using System;

class Program
{
    // 1. Define the Delegate type
    // This delegate can point to any method that takes two ints and returns an int.
    public delegate int OperationDelegate(int x, int y);

    static void Main()
    {
        int num1 = 20, num2 = 10;

        Console.WriteLine($"Numbers: {num1} and {num2}\n");

        // 2. Pass methods to PerformOperation using the delegate
        // Passing the 'Add' method
        PerformOperation(num1, num2, Add);

        // Passing the 'Subtract' method
        PerformOperation(num1, num2, Subtract);

        // 3. You can also use Lambda Expressions (shorthand)
        PerformOperation(num1, num2, (a, b) => a * b); // Multiply
    }

    // This method accepts a delegate as a parameter
    static void PerformOperation(int a, int b, OperationDelegate operation)
    {
        // Execute the method that was passed in
        int result = operation(a, b);

        // Use Method.Name to see which operation was performed
        Console.WriteLine($"{operation.Method.Name} Result: {result}");
    }

    // Target method for addition
    static int Add(int a, int b) => a + b;

    // Target method for subtraction
    static int Subtract(int a, int b) => a - b;
}