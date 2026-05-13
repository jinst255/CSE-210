using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;



class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the journal program! What would you like to do?");
        DisplayOptions();

        string userCommand = "";
        Journal myJournal = new Journal();


        while (userCommand != "6")
        {
            Console.WriteLine("Enter your choice (1-6):");
            userCommand = Console.ReadLine();

            if (userCommand == "1")
            {
                // Handle writing a new journal entry
                Console.WriteLine("Please enter your journal entry:");
                string entryText = Console.ReadLine();


            }
            else if (userCommand == "2")
            {
                // Handle displaying journal entries

            }
            else if (userCommand == "3")
            {
                // Handle loading journal from a file
            }
            else if (userCommand == "4")
            {
                // Handle saving journal to a file
                // myJournal.Save(myJournal, "journalEntry.txt");
            }
            else if (userCommand == "5")
            {
                // Handle clearing the screen
                Console.Clear();
                Console.WriteLine("Screen cleared.");
            }
            else if (userCommand != "6")
            {
                Console.WriteLine("Invalid option. Please enter a number between 1 and 6.");
            }

        } 
        

        /*
        Console.Clear();
        Journal myJournal = new Journal();

        Console.WriteLine("Welcome to your journal! Please enter your journal entry:");
        string entryText = Console.ReadLine();

        myJournal.Save(entryText, "journalEntry.txt");
        Console.WriteLine();
        myJournal.Load("journalEntry.txt");
        */
    }
    public static void DisplayOptions()
    {
        Console.WriteLine("1. Write a new journal entry");
        Console.WriteLine("2. Display journal entries");
        Console.WriteLine("3. Load journal from a file");
        Console.WriteLine("4. Save journal to a file");
        Console.WriteLine("5. Clear the screen");
        Console.WriteLine("6. Quit");
    }
} 


class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void Save(string entryText, string fileName)
    {
        // Write to a file
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(entryText); 
        }

        Console.WriteLine($"File created at: {Path.GetFullPath(fileName)}\n the file is named: {fileName}");
    }

    public void Load(string fileName)
    {
        // check if the file exists before trying to read it
        if (File.Exists(fileName))
        {
            using (StreamReader inputFile = new StreamReader(fileName))
            {
                string content = inputFile.ReadToEnd();
                Console.WriteLine("File content:");
                Console.WriteLine(content);
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
    string _entry;
    string _usedPrompt;
    string _timeStamp;
    string _currentMood;

    public void Display()
    {
        Console.WriteLine($"Prompt: {_usedPrompt}");
        Console.WriteLine($"Entry: {_entry}");
        Console.WriteLine($"Mood: {_currentMood}");
        Console.WriteLine($"Time: {_timeStamp}");
    }
}


