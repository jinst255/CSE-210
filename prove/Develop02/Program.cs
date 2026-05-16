using System;
using System.IO;
using System.Collections.Generic;

/*
Exceed requirements:
- Added a clear option
- Added a mood field
- Added a option to count the char count from a saved file
*/

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the journal program! What would you like to do?");
        DisplayOptions();

        string userCommand = "";
        Journal myJournal = new Journal();
        

        while (userCommand != "7")
        {
            Console.WriteLine("Enter your choice (1-7):");
            userCommand = Console.ReadLine();

            if (userCommand == "1")
            {
                /*
                Collect the following for the journal entry:
                    public string _timeStamp;   -- Done
                    public string _usedPrompt;  -- Done
                    string _entry;              -- Done
                    public string _currentMood; -- Done
                */
                
                // Display a random prompt for the user and take input
                Random random = new Random();
                int rand_index = random.Next(myJournal._prompts.Count);

                Console.WriteLine($"Here is your prompt for today: {myJournal._prompts[rand_index]}");
                Console.Write("> ");
                string entryText = Console.ReadLine();

                Console.Write("What is your current mood? ");
                string currentMood = Console.ReadLine();

                // Append the new entry to the list of entries in the journal
                Entry newEntry = new Entry();
                newEntry._entry = entryText;
                newEntry._usedPrompt = myJournal._prompts[rand_index];
                newEntry._currentMood = currentMood;
                newEntry._timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                myJournal.AddEntry(newEntry);

                Console.WriteLine();
                // myJournal._entries[myJournal._entries.Count - 1].Display(); // For deugging, shows the most recently added entry
            }
            else if (userCommand == "2")
            {
                // Handle displaying journal entries
                Console.WriteLine("Journal Entries Currently Loaded:");
                Console.WriteLine("-----------------------------");

                // iterate through all of the loaded entries and display them
                for (int i = 0; i < myJournal._entries.Count; i++)
                {
                    myJournal._entries[i].Display();
                    Console.WriteLine("-----------------------------\n");
                }
            }
            else if (userCommand == "3")
            {
                // Handle loading journal from a file
                Console.Write("Enter the filename to load: ");
                string fileName = Console.ReadLine();
                myJournal.Load(fileName);
                Console.WriteLine("Journal loaded successfully.");
            }
            else if (userCommand == "4")
            {
                // Handle saving journal to a file
                Console.Write("Enter the filename to save: ");
                string fileName = Console.ReadLine();
                myJournal.Save(fileName);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (userCommand == "5")
            {
                // Handle clearing the screen
                Console.Clear();
                DisplayOptions();
            }
            else if (userCommand == "6")
            {
                // Handle showing character count for saved journal file
                Console.Write("Enter the filename to check character count: ");
                string fileName = Console.ReadLine();
                if (File.Exists(fileName))
                {
                    string fileContents = File.ReadAllText(fileName);
                    int charCount = fileContents.Length;
                    Console.WriteLine($"The character count for the file '{fileName}' is: {charCount}");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            else if (userCommand != "7")
            {
                Console.WriteLine("Invalid option. Please enter a number between 1 and 7.");
            }

        } 
        

    }
    public static void DisplayOptions()
    {
        Console.WriteLine("1. Write a new journal entry");
        Console.WriteLine("2. Display journal entries");
        Console.WriteLine("3. Load journal from a file");
        Console.WriteLine("4. Save journal to a file");
        Console.WriteLine("5. Clear the screen");
        Console.WriteLine("6. Show char count for saved journal file");
        Console.WriteLine("7. Quit");
    }
} 


class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public List<string> _prompts = new List<string>()
    {
        "If I had one thing I could do over today, what would it be?",
        "What am I grateful for today?",
        "What is something that made me smile today?",
        "What is a challenge I faced today and how did I overcome it?",
        "What is a goal I have for tomorrow?",
        "What is something I learned today?",
        "What was my favorite part of the day?"
    };

    public void AddEntry(Entry entryToAdd)
    {
        _entries.Add(entryToAdd);
    }

    public void Save(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._usedPrompt}|{entry._entry}|{entry._currentMood}|{entry._timeStamp}");
            }
        }
    }

    public void Load(string fileName)
    {
        if (File.Exists(fileName))
        {
            // this clear will get rid of exsisting entries in the journal before we load from the file
            _entries.Clear();

            string[] lines = System.IO.File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                if (parts.Length == 4)
                {
                    AddEntry(new Entry() {_usedPrompt = parts[0], _entry = parts[1], _currentMood = parts[2], _timeStamp = parts[3]});
                }
            }
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}




class Entry
{
    public string _entry;
    public string _usedPrompt;
    public string _timeStamp;
    public string _currentMood;

    public void Display()
    {
        Console.WriteLine($"Prompt: {_usedPrompt}");
        Console.WriteLine($"Entry: {_entry}");
        Console.WriteLine($"Mood: {_currentMood}");
        Console.WriteLine($"Time: {_timeStamp}");
    }
}


