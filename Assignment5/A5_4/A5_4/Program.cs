using System;

// 1. Define the Delegate type
public delegate void NotificationHandler(string message);

class Logger
{
    // Instance method for Console logging
    public void LogToConsole(string message)
    {
        Console.WriteLine($"[CONSOLE]: {message}");
    }

    // Instance method for File logging (simulated)
    public void LogToFile(string message)
    {
        Console.WriteLine($"[FILE]: Writing '{message}' to log.txt...");
    }
}

class Program
{
    static void Main()
    {
        // a & b. Create instance of the Logger class
        Logger myLogger = new Logger();

        // c. Instantiate the delegate and combine methods using the + operator
        // Point to the first method
        NotificationHandler notifier = myLogger.LogToConsole;

        // Use the + operator to add the second method to the delegate chain
        notifier += myLogger.LogToFile;

        Console.WriteLine("Invoking the delegate chain once:");
        Console.WriteLine("---------------------------------");

        // d. Invoke the delegate once
        // This will trigger BOTH LogToConsole and LogToFile
        notifier("System update successful.");

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Both logging actions were completed.");
    }
}