using System;
using System.Collections.Generic;

class Program
{
        static void Main(string[] args)
        {
            Console.WriteLine(false);

            // (Exceeds requirements)
            // I made it so that HideRandomWord() will always choose a word that has not already been hidden. 

            // 1 Nephi 1:1-2 (I know --- its hard coded)
            string text = "I, Nephi, having been born of goodly parents, therefore I was taught somewhat in all the learning of my father; and having seen many afflictions in the course of my life, nevertheless, having been highly favored of the Lord in all my days; yea, having had a great knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings in my days. Yea, I make a record in the language of my father, which consists of the learning of the Jews and the language of the Egyptians.";
            Reference reference = new Reference("1 Nephi", 1, 1, 2); // setup the reference

            Scripture scripture = new Scripture(reference, text); // create the scripture object

            // runless the user quits or all words are hidden
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                scripture.Display();

                Console.WriteLine("\n\nPress enter to hide words. Type 'quit' if you want to quit.");
                string userChoice = Console.ReadLine();
                if (userChoice.ToLower() == "quit")
                {
                    Console.WriteLine("Try again soon!");
                    return; // Stop the program
                }
                else
                {
                    scripture.HideRandomWord();
                }
            }

            // Final display after loop ends
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nThats all of'em Chau! (Bye in Argentinian Spanish)");
        }
}


class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // convert the text string into a list which we will store in _words
        _words = BuildList(text);
    }

    private List<Word> BuildList(string text)
    {
        // Make the list
        List<Word> words = new List<Word>();
        
        // Split the text into words
        string[] textWords = text.Split(' ');

        // Loop through and add them to the list
        foreach (string w in textWords)
        {
            words.Add(new Word(w));
        }
        return words;
    }

    public void Display()
    {
        Console.WriteLine($"Reference: {_reference.GetDisplayReference()}");
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        // Console.WriteLine();
    }
    public void HideRandomWord()
    {
        Random rand = new Random();
        int index = rand.Next(_words.Count); 

        // check if the word is already hidden, if so, try again
        while (_words[index].IsHidden()) // This generates a rand between 0 and the count of words in the list
        {
            index = rand.Next(_words.Count);
        }

        _words[index].Hide();
        }
    
    public bool IsCompletelyHidden() // only return true if all words are hidden
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true; 
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // We need 2 constructors because the end verse is optional.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse; 
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public string GetDisplayReference()
    {
        if (_startVerse == _endVerse) // if the start and end verse are the same, return book chapter: verse
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else // else return book chapter: startVerse - endVerse
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}


class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (_isHidden == true) // if the word's hidden return the needed amount of _ else return the word
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}