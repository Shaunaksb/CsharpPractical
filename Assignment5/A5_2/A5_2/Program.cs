using System;

class Program
{
    // 1. Define the delegate that returns a bool and takes an int
    public delegate bool CheckNumber(int number);

    static void Main()
    {
        // 2. Instantiate the delegate pointing to the IsEven method
        CheckNumber evenPredicate = IsEven;

        int testValue = 42;

        // 3. Call the delegate and display the result
        bool result = evenPredicate(testValue);

        Console.WriteLine($"Is {testValue} even? {result}");
    }

    // The method the delegate will point to
    static bool IsEven(int n)
    {
        return n % 2 == 0;
    }
}