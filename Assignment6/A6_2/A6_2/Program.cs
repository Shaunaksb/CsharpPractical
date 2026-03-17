using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "sample.txt";

        try
        {
            // 1. Check if file exists; if not, create one for the example
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Hello world!\nThis is a C# file test.\nLearning is fun.");
            }

            // 2. Read all text from the file
            string content = File.ReadAllText(filePath);

            // 3. Count Lines
            // We split by the newline character. StringSplitOptions.None ensures we count empty lines.
            string[] lines = content.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
            int lineCount = lines.Length;

            // 4. Count Words
            // We split by whitespace (spaces, tabs, newlines) and remove empty entries
            string[] words = content.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;

            // 5. Count Characters
            int charCount = content.Length;

            // Display Results
            Console.WriteLine($"File: {filePath}");
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Total Lines:      {lineCount}");
            Console.WriteLine($"Total Words:      {wordCount}");
            Console.WriteLine($"Total Characters: {charCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}