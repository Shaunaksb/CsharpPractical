using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFile = "data.txt";
        string destinationFile = "copy.txt";

        try
        {
            // 0. Create a sample data.txt if it doesn't exist for the demo
            if (!File.Exists(sourceFile))
            {
                File.WriteAllText(sourceFile, "Hello! This is the original content of data.txt.");
            }

            // 1. Copy content from data.txt to copy.txt
            // The 'true' parameter allows overwriting if copy.txt already exists
            File.Copy(sourceFile, destinationFile, true);
            Console.WriteLine("File copied successfully.\n");

            // 2. Read and Display content of data.txt
            string originalContent = File.ReadAllText(sourceFile);
            Console.WriteLine($"--- Contents of {sourceFile} ---");
            Console.WriteLine(originalContent);

            // 3. Read and Display content of copy.txt
            string copiedContent = File.ReadAllText(destinationFile);
            Console.WriteLine($"\n--- Contents of {destinationFile} ---");
            Console.WriteLine(copiedContent);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: The source file 'data.txt' was not found.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"An I/O error occurred: {e.Message}");
        }
    }
}