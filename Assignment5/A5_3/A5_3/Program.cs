using System;
using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name.PadRight(10)} (Age: {Age})";
    }
}

class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>
        {
            new Person("Diana", 30),
            new Person("Alice", 25),
            new Person("Charlie", 35),
            new Person("Bob", 22)
        };

        Console.WriteLine("Original List:");
        PrintList(people);

        // a. Sort by Name using a delegate (Lambda expression)
        // Comparison<T> delegate takes (x, y) and returns -1, 0, or 1
        people.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
        Console.WriteLine("\nSorted by Name:");
        PrintList(people);

        // b. Sort by Age using a delegate
        people.Sort((p1, p2) => p1.Age.CompareTo(p2.Age));
        Console.WriteLine("\nSorted by Age:");
        PrintList(people);
    }

    static void PrintList(List<Person> list)
    {
        foreach (var person in list)
        {
            Console.WriteLine(person);
        }
    }
}