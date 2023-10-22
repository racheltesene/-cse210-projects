using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Text { get; private set; }
    public bool Hidden { get; set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }
}

class ScriptureReference
{
    public string Reference { get; private set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }
}

class Scripture
{
    private List<Word> words;
    private int hiddenWordCount;

    public Scripture(ScriptureReference reference, string text)
    {
        words = text.Split(' ').Select(w => new Word(w)).ToList();
        hiddenWordCount = 0;
        Reference = reference;
    }

    public ScriptureReference Reference { get; private set; }

    public bool AllWordsHidden => hiddenWordCount == words.Count;

    public void HideRandomWord()
    {
        if (hiddenWordCount < words.Count)
        {
            Random random = new Random();
            int randomIndex = random.Next(words.Count);
            Word wordToHide = words[randomIndex];
            if (!wordToHide.Hidden)
            {
                wordToHide.Hidden = true;
                hiddenWordCount++;
            }
        }
    }

    public string GetVisibleText()
    {
        return string.Join(" ", words.Select(w => w.Hidden ? new string('*', w.Text.Length) : w.Text));
    }
}

class Program
{
    static void Main()
    {
        // Create a Scripture object with the reference and text
        var reference = new ScriptureReference("John 3:16");
        var text = "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        var scripture = new Scripture(reference, text);

        Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");

        while (!scripture.AllWordsHidden)
        {
            Console.Clear();
            Console.WriteLine(scripture.Reference);
            Console.WriteLine(scripture.GetVisibleText());

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        }
    }
}
