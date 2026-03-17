using System;
using System.Collections.Generic;
using System.Linq;

class Process
{
    public int Id { get; set; }
    public int BurstTime { get; set; }
    public int WaitingTime { get; set; }
    public int TurnAroundTime { get; set; }

    public Process(int id, int burstTime)
    {
        Id = id;
        BurstTime = burstTime;
    }
}

class Program
{
    static void Main()
    {
        List<Process> processes = new List<Process>
        {
            new Process(1, 6),
            new Process(2, 8),
            new Process(3, 7),
            new Process(4, 3)
        };

        // 1. Sort processes by Burst Time (The core logic of SJF)
        var sjfQueue = processes.OrderBy(p => p.BurstTime).ToList();

        int totalWaiting = 0;
        int totalTurnAround = 0;

        // 2. Calculate Waiting Time and TurnAround Time
        // First process in SJF has 0 waiting time
        sjfQueue[0].WaitingTime = 0;
        sjfQueue[0].TurnAroundTime = sjfQueue[0].BurstTime;

        for (int i = 1; i < sjfQueue.Count; i++)
        {
            // Waiting time = Burst time of previous process + Waiting time of previous process
            sjfQueue[i].WaitingTime = sjfQueue[i - 1].BurstTime + sjfQueue[i - 1].WaitingTime;

            // Turnaround time = Waiting time + Burst time
            sjfQueue[i].TurnAroundTime = sjfQueue[i].WaitingTime + sjfQueue[i].BurstTime;

            totalWaiting += sjfQueue[i].WaitingTime;
            totalTurnAround += sjfQueue[i].TurnAroundTime;
        }

        // Add the first process's TAT to total (it was skipped in the loop for total calculation)
        totalTurnAround += sjfQueue[0].TurnAroundTime;

        // 3. Display Results
        Console.WriteLine("P_ID\tBurst\tWaiting\tTurnAround");
        foreach (var p in sjfQueue)
        {
            Console.WriteLine($"{p.Id}\t{p.BurstTime}\t{p.WaitingTime}\t{p.TurnAroundTime}");
        }

        Console.WriteLine($"\nAverage Waiting Time: {(double)totalWaiting / sjfQueue.Count:F2}");
        Console.WriteLine($"Average Turnaround Time: {(double)totalTurnAround / sjfQueue.Count:F2}");
    }
}