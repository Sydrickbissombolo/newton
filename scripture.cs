using System;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John", 3, 16);
        while (!scripture.IsComplete() && !scripture.IsQuit())
        {
            Console.WriteLine(scripture.Display());
            Console.Write("Enter 'hide' to hide a word or 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input == "hide")
            {
                Console.Write("Enter the word index to hide: ");
                int wordIndex = int.Parse(Console.ReadLine());
                scripture.HideWord(wordIndex);
            }
            else if (input == "quit")
            {
                scripture.Quit();
            }
            Console.WriteLine();
        }
    }
}

class Scripture
{
    private Reference reference;
    private Word[] words;
    private bool quit;

    public Scripture(string book, int chapter, int verse)
    {
        reference = new Reference(book, chapter, verse);
        words = new Word[]
        {
            new Word("For", false),
            new Word("God", false),
            new Word("so", false),
            new Word("loved", false),
            new Word("the", false),
            new Word("world", false),
            new Word("that", false),
            new Word("he", false),
            new Word("gave", false),
            new Word("his", false),
            new Word("only", false),
            new Word("Son,", false),
            new Word("that", false),
            new Word("whoever", false),
            new Word("believes", false),
            new Word("in", false),
            new Word("him", false),
            new Word("shall", false),
            new Word("not", false),
            new Word("perish", false),
            new Word("but", false),
            new Word("have", false),
            new Word("eternal", false),
            new Word("life.", false)
        };
        quit = false;
    }

    public void HideWord(int index)
    {
        if (index >= 0 && index < words.Length)
        {
            words[index].Hide();
        }
    }

    public bool IsComplete()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public bool IsQuit()
    {
        return quit;
    }

    public void Quit()
    {
        quit = true;
    }

    public string Display()
    {
        string displayText = $"{reference.Display()}\n";
        foreach (Word word in words)
        {
            displayText += word.Display() + " ";
        }
        return displayText.Trim();
    }
}

class Word
{
    private string text;
    private bool hidden;

    public Word(string text, bool hidden)
    {
        this.text = text;
        this.hidden = hidden;
    }

    public void Hide()
    {
        hidden = true;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public string Display()
    {
        return hidden ? "_____" : text;
    }
}

class Reference
{
    private string book;
    private int chapter;
    private int verse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public string Display()
    {
        return $"{book} {chapter}:{verse}";
    }
}
