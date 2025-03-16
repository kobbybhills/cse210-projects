using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string filename = "journal.txt";

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved.");
                    break;
                case "4":
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded.");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private static readonly Random random = new Random();
    private static readonly string[] prompts =
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "Describe a challenge you faced and how you handled it.",
        "Write about something that made you smile today."
    };

    public void AddEntry()
    {
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        entries.Add(new Entry(DateTime.Now, prompt, response));
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                entries.Add(Entry.FromFileFormat(line));
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Entry
{
    public DateTime Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"[{Date}] {Prompt}\n{Response}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        return new Entry(DateTime.Parse(parts[0]), parts[1], parts[2]);
    }
}
