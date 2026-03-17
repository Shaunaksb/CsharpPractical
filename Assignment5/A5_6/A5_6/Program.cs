using System;

class Program
{
    static void Main()
    {
        int x = 20;
        int y = 10;

        Console.WriteLine($"Base Numbers: {x} and {y}");
        Console.WriteLine("-------------------------");

        // 1. Passing an Addition lambda
        int sum = ExecuteOperation(x, y, (a, b) => a + b);
        Console.WriteLine($"Addition Result:       {sum}");

        // 2. Passing a Subtraction lambda
        int diff = ExecuteOperation(x, y, (a, b) => a - b);
        Console.WriteLine($"Subtraction Result:    {diff}");

        // 3. Passing a Multiplication lambda
        int product = ExecuteOperation(x, y, (a, b) => a * b);
        Console.WriteLine($"Multiplication Result: {product}");

        // 4. Passing a Division lambda
        int quotient = ExecuteOperation(x, y, (a, b) => a / b);
        Console.WriteLine($"Division Result:       {quotient}");
    }

    // The method that accepts the lambda (Func delegate)
    static int ExecuteOperation(int num1, int num2, Func<int, int, int> operation)
    {
        // We simply call the delegate 'operation' as if it were a method
        return operation(num1, num2);
    }
}