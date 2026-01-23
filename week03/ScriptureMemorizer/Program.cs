// For my enhancement I added a text file that has several different scriptures that are randomized. This way you can practice different scriptures at a time.
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = LoadRandomScripture("scriptures.txt");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }

    static Scripture LoadRandomScripture(string filename)
    {
        string fullPath = @"C:\Users\tanne\OneDrive\Homework\CSE210-HW\week03\ScriptureMemorizer\scriptures.txt";

        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"ERROR: scriptures.txt not found at:");
            Console.ReadLine();
            Environment.Exit(1);
        }

        string[] allLines = File.ReadAllLines(fullPath);

        var validLines = new System.Collections.Generic.List<string>();

        foreach (string line in allLines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split('|');

            if (parts.Length == 5)
            {
                validLines.Add(line);
            }
        }

        if (validLines.Count == 0)
        {
            Console.WriteLine("ERROR: No valid scriptures found in file.");
            Console.ReadLine();
            Environment.Exit(1);
        }

        Random random = new Random();
        string chosenLine = validLines[random.Next(validLines.Count)];

        string[] data = chosenLine.Split('|');

        string book = data[0];
        int chapter = int.Parse(data[1]);
        int startVerse = int.Parse(data[2]);
        int endVerse = int.Parse(data[3]);
        string text = data[4].Trim();

        Reference reference = startVerse == endVerse
            ? new Reference(book, chapter, startVerse)
            : new Reference(book, chapter, startVerse, endVerse);

        return new Scripture(reference, text);
    }
}