using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        List<Goal> goals = new List<Goal>();
        int currentScore = 0;

        string userChoice = "";
        while (userChoice != "6")
        {
            Console.Clear();
            SetColor("header");
            Console.WriteLine($"\nYou have {currentScore} points\n");
            SetColor("default");
            PrintOptions();

            SetColor("userInput");
            Console.Write("Select a choice from the menu: ");
            SetColor("default");
            userChoice = Console.ReadLine();


            if (userChoice == "1")
            {
                // Create New Goal
                SetColor("header");
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                SetColor("userInput");
                Console.Write("Which type of goal would you like to create? ");
                SetColor("default");
                string goalType = Console.ReadLine();

                SetColor("userInput");
                Console.Write("What is the name of your goal? ");
                SetColor("default");
                string name = Console.ReadLine();

                SetColor("userInput");
                Console.Write("What is a short description of it? ");
                SetColor("default");
                string description = Console.ReadLine();

                SetColor("userInput");
                Console.Write("What is the amount of points associated with this goal? ");
                SetColor("default");
                int pointValue = int.Parse(Console.ReadLine());

                if (goalType == "1")
                {
                    goals.Add(new SimpleGoal(name, description, pointValue));
                }
                else if (goalType == "2")
                {
                    goals.Add(new EternalGoal(name, description, pointValue));
                }
                else if (goalType == "3")
                {
                    SetColor("userInput");
                    Console.Write("What is the bonus points for this goal? ");
                    SetColor("default");
                    int _bonusPoints = int.Parse(Console.ReadLine());
                    SetColor("userInput");
                    Console.Write("What is the repetition goal for this goal? ");
                    SetColor("default");
                    int _repsGoal = int.Parse(Console.ReadLine());

                    goals.Add(new ChecklistGoal(name, description, pointValue, _bonusPoints, _repsGoal));
                }

            }
            else if (userChoice == "2")
            {
                // List Goals
                SetColor("header");
                Console.WriteLine("The goals are:");
                SetColor("default");
                foreach (Goal g in goals)
                {
                    Console.WriteLine(g.DisplayGoal());
                }
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
            else if (userChoice == "3")
            {
                // Save Goals
                SetColor("userInput");
                Console.Write("What is the filename for the goal file? ");
                SetColor("default");
                string filename = Console.ReadLine();
                List<string> lines = new List<string>();

                lines.Add(currentScore.ToString()); // add in the score to the file

                foreach (Goal g in goals)
                {
                    lines.Add(g.StringForFile()); 
                }
                File.WriteAllLines(filename, lines);
                Console.WriteLine($"Goals saved to {filename}");
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }

            else if (userChoice == "4")
            {
                // Load Goals
                SetColor("userInput");
                Console.Write("What is the filename for the goal file? ");
                SetColor("default");
                string filename = Console.ReadLine();
                if (!File.Exists(filename))
                {
                    Console.WriteLine($"File '{filename}' not found.");
                    continue;
                }
                string[] lines = File.ReadAllLines(filename);
                goals.Clear();

                currentScore = int.Parse(lines[0]); // get the score from the file

                foreach (string line in lines[1..])
                {
                    string[] parts = line.Split("|");
                    string type = parts[0];
                    string data = line.Substring(type.Length + 1); // I needed to extract a sub string);
                    if (type == "SimpleGoal")
                    {
                        SimpleGoal g = new SimpleGoal("", "", 0);
                        g.DesconstructFromFile(data);
                        goals.Add(g);
                    }
                    else if (type == "EternalGoal")
                    {
                        EternalGoal g = new EternalGoal("", "", 0);
                        g.DesconstructFromFile(data);
                        goals.Add(g);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        ChecklistGoal g = new ChecklistGoal("", "", 0, 0, 0);
                        g.DesconstructFromFile(data);
                        goals.Add(g);
                    }
                }
                Console.WriteLine("Goals loaded!");
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
            else if (userChoice == "5")
            {
                // Record Event
                Console.WriteLine("The goals are:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].DisplayGoal()}");
                }

                Console.Write("Which goal did you accomplish? ");
                int goalIndex = int.Parse(Console.ReadLine()) - 1;
                int pointsEarned = goals[goalIndex].RecordEvent();
                currentScore += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points!");
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
            else if (userChoice == "6")
            {
                Console.WriteLine("Chau! (Bye in Argentinian Spanish)");
            }
            else
            {
                Console.WriteLine("\nYou may only pick a number from 1-6. Try again.");
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
        }
    }

    public static void PrintOptions()
    {
        SetColor("header");
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        SetColor("default");
    }
    public static void SetColor(string color)
    {
        if (color == "header")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        else if (color == "userInput")
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else // the default color is white
        {
            Console.ResetColor();
        }
    }
}