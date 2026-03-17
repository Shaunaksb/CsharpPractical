using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{Name.PadRight(10)} | Salary: {Salary:C}";
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee("Alice", 75000),
            new Employee("Charlie", 50000),
            new Employee("Bob", 60000),
            new Employee("Diana", 75000), // Same salary as Alice
            new Employee("Edward", 45000)
        };

        // 1. Sort by Salary (Ascending)
        // If Salaries are equal, then sort by Name (Alphabetical)
        var sortedEmployees = employees
            .OrderBy(e => e.Salary)
            .ThenBy(e => e.Name)
            .ToList();

        Console.WriteLine("Employees sorted by Salary (then Name):");
        Console.WriteLine("---------------------------------------");
        foreach (var emp in sortedEmployees)
        {
            Console.WriteLine(emp);
        }
    }
}