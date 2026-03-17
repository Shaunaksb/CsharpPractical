using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Reference string (sequence of page requests)
        int[] pages = { 7, 0, 1, 2, 0, 3, 0, 4, 2, 3, 0, 3, 2 };
        int capacity = 3; // Total number of frames in memory

        FIFOPageReplacement(pages, capacity);
    }

    static void FIFOPageReplacement(int[] pages, int capacity)
    {
        // To track pages currently in memory for quick lookup
        HashSet<int> memorySet = new HashSet<int>();

        // To track the order of pages for replacement (FIFO)
        Queue<int> fifoQueue = new Queue<int>();

        int pageFaults = 0;

        Console.WriteLine("Incoming | Memory Frames | Status");
        Console.WriteLine("---------|---------------|-------");

        foreach (int page in pages)
        {
            // Check if page is NOT in memory (Page Fault)
            if (!memorySet.Contains(page))
            {
                // If memory is full, remove the oldest page
                if (fifoQueue.Count == capacity)
                {
                    int oldest = fifoQueue.Dequeue();
                    memorySet.Remove(oldest);
                }

                // Add the new page
                fifoQueue.Enqueue(page);
                memorySet.Add(page);

                pageFaults++;
                DisplayStatus(page, fifoQueue, "FAULT");
            }
            else
            {
                // Page is already in memory (Page Hit)
                DisplayStatus(page, fifoQueue, "HIT");
            }
        }

        Console.WriteLine("\nTotal Page Faults: " + pageFaults);
    }

    static void DisplayStatus(int current, Queue<int> queue, string status)
    {
        string frames = string.Join(", ", queue);
        Console.WriteLine($"{current,-8} | [{frames,-11}] | {status}");
    }
}