using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Initialize the Queue
        Queue<string> ticketLine = new Queue<string>();

        // 2. Customers join the line (Enqueue)
        Console.WriteLine("--- Customers joining the line ---");
        JoinLine(ticketLine, "Alice");
        JoinLine(ticketLine, "Bob");
        JoinLine(ticketLine, "Charlie");
        JoinLine(ticketLine, "Diana");

        Console.WriteLine($"\nCurrent line length: {ticketLine.Count}");
        Console.WriteLine("Next person to be served: " + ticketLine.Peek());

        // 3. Process the bookings (Dequeue)
        Console.WriteLine("\n--- Processing Bookings ---");
        while (ticketLine.Count > 0)
        {
            string currentCustomer = ticketLine.Dequeue();
            Console.WriteLine($"Booking confirmed for: {currentCustomer}");
            Console.WriteLine($"Remaining in line: {ticketLine.Count}");
        }

        Console.WriteLine("\nAll tickets booked. The line is now empty.");
    }

    static void JoinLine(Queue<string> queue, string name)
    {
        queue.Enqueue(name);
        Console.WriteLine($"{name} has entered the line.");
    }
}