// Added an option for JSON files to be saved and loaded instead of using regular txt or csv files.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.\n");
            return;
        }

        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(Entries, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. \n");
            return;
        }

        string json = File.ReadAllText(filename);
        Entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
        Console.WriteLine("Journal loaded succesfully!\n");
    }
}