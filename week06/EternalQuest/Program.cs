/*
EXCEEDING REQUIREMENTS DESCRIPTION

I implemented a Leveling System to gamify the experience.

1. The player levels up every 1000 points.
2. The current level is displayed in the main menu.
3. As the level increases, goals reward bonus points based on level.
   - Simple & Checklist: +10 points per level
   - Eternal: +5 points per level
4. Level is saved and loaded with the file.

This adds difficulty scaling and increased motivation.
*/

using System;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalScore = 0;
    static int level = 1;
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            UpdateLevel();

            Console.WriteLine("\n===== Eternal Quest =====");
            Console.WriteLine($"Score: {totalScore} | Level: {level}");
            Console.WriteLine("1) Create Goal");
            Console.WriteLine("2) Record Event");
            Console.WriteLine("3) Show Goals");
            Console.WriteLine("4) Save Goals");
            Console.WriteLine("5) Load Goals");
            Console.WriteLine("6) Quit");
            Console.Write("Select: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
    }
}
static void UpdateLevel()
    {
        level = (totalScore / 1000) + 1;
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1) Simple Goal");
        Console.WriteLine("2) Eternal Goal");
        Console.WriteLine("3) Checklist Goal");
        Console.Write("Choice: ");

        string type = Console.ReadLine();

        Console.Write("Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, points));
        }
        else if (type == "3")
        {
            Console.Write("Required Completions: ");
            int required = int.Parse(Console.ReadLine());

            Console.Write("Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, points, required, bonus));
        }
    }
     static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent(level);
            totalScore += earned;

            UpdateLevel();

            Console.WriteLine($"You earned {earned} points!");
            Console.WriteLine($"New Score: {totalScore}");
            Console.WriteLine($"Current Level: {level}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
    static void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {goals[i].GetStatus()}");
        }
    }
     static void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string file = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine(totalScore);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }
     static void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        goals.Clear();

        string[] lines = File.ReadAllLines(file);
        totalScore = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            switch (parts[0])
            {
                case "Simple":
                    goals.Add(new SimpleGoal(parts[1], int.Parse(parts[2])));
                    break;

                case "Eternal":
                    goals.Add(new EternalGoal(parts[1], int.Parse(parts[2])));
                    break;

                case "Checklist":
                    goals.Add(new ChecklistGoal(
                        parts[1],
                        int.Parse(parts[2]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5])
                    ));
                    break;
            }
        }

        UpdateLevel();
        Console.WriteLine("Goals loaded successfully.");
    }
}