// In my Journal.cs file, I added (Added an option for JSON files to be saved and loaded instead of using regular txt or csv files.)
// In my Entry.cs file I added (Added an extra part in here that shows a timestamp of when you added your entry.)

//Both files have the same notes, just wanted to make sure this had all the enhancements listed.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry entry = new Entry
                    {
                        Date = DateTime.Now.ToShortDateString(),
                        Time = DateTime.Now.ToShortTimeString(),
                        Prompt = prompt,
                        Response = response
                    };

                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added!\n");
                    break;
                
                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save (example: journal.json): ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Enter filename to load (example: journal.json): ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid Option. \n");
                    break;
            }
        }
    }
}