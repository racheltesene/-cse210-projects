using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        bool continueJournaling = true;

        while (continueJournaling)
        {
            Console.WriteLine("Journaling App Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int choice = GetUserChoice(1, 5);

            switch (choice)
            {
                case 1:
                    journal.WriteNewEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter the filename to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;
                case 4:
                    Console.Write("Enter the filename to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;
                case 5:
                    continueJournaling = false;
                    break;
            }
        }
    }

    static int GetUserChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine($"Please enter a number between {min} and {max}: ");
        }
        return choice;
    }
}

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
}

class Journal
{
    private List<JournalEntry> entries;
    private List<string> prompts;

    public Journal()
    {
        entries = new List<JournalEntry>();
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public void WriteNewEntry()
    {
        JournalEntry entry = new JournalEntry();
        entry.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        entry.Prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {entry.Prompt}");
        Console.Write("Your response: ");
        entry.Response = Console.ReadLine();
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine();
            }
        }
        Console.WriteLine("Journal saved to file successfully.");
    }

    public void LoadJournalFromFile(string fileName)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            JournalEntry entry = null;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line.StartsWith("Date: "))
                {
                    entry = new JournalEntry();
                    entry.Date = line.Substring(6);
                }
                else if (line.StartsWith("Prompt: "))
                {
                    entry.Prompt = line.Substring(8);
                }
                else if (line.StartsWith("Response: "))
                {
                    entry.Response = line.Substring(10);
                    entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded from file successfully.");
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(prompts.Count);
        return prompts[index];
    }
}