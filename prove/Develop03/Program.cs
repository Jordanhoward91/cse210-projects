using System;
using System.Collections.Generic;
using System.Linq;

class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int VerseStart { get; private set; }
    public int VerseEnd { get; private set; }

    public ScriptureReference(string book, int chapter, int verseStart, int verseEnd = 0)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd == 0 ? verseStart : verseEnd;
    }

    public override string ToString()
    {
        if (VerseStart == VerseEnd)
        {
            return $"{Book} {Chapter}:{VerseStart}";
        }
        else
        {
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
    }
}

class ScriptureWord
{
    public string Text { get; private set; }
    public bool Hidden { get; private set; }

    public ScriptureWord(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public override string ToString()
    {
        return Hidden ? "_____" : Text;
    }
}

class Scripture
{
    private readonly List<ScriptureWord> words;
    public ScriptureReference Reference { get; private set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
    }

    public void HideRandomWords()
    {
        var wordsToHide = words.Where(word => !word.Hidden).ToList();
        if (wordsToHide.Count > 0)
        {
            Random random = new Random();
            int index = random.Next(0, wordsToHide.Count);
            wordsToHide[index].Hide();
        }
    }

    public bool IsFullyHidden()
    {
        return words.All(word => word.Hidden);
    }

    public override string ToString()
    {
        string text = string.Join(" ", words.Select(word => word.ToString()));
        return $"{Reference}\n{text}";
    }
}

class Program
{
    private static void Main(string[] args)
    {
        Scripture scripture1 = new Scripture(
            new ScriptureReference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        );

        Scripture scripture2 = new Scripture(
            new ScriptureReference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
        );

        List<Scripture> scriptures = new List<Scripture> { scripture1, scripture2 };

        Program program = new Program();
        program.Run(scriptures);
    }

    private void ClearConsole()
    {
        Console.Clear();
    }

    private void Run(List<Scripture> scriptures)
    {
        Random random = new Random();
        while (true)
        {
            ClearConsole();
            Scripture scripture = scriptures[random.Next(0, scriptures.Count)];
            Console.WriteLine(scripture);
            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("All words are hidden. Program will end now.");
                break;
            }

            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit:");
            string userInput = Console.ReadLine()?.Trim().ToLower();
            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
            System.Threading.Thread.Sleep(1000); // Add a slight delay for better user experience
        }
    }
}
