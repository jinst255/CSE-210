using System;


// In order to exceed requirements I added some color to the console. 


class Program
{
    static void Main(string[] args)
    {
        string userChoice = "";
        while (userChoice != "4")
        {
            Console.Clear();
            SetConsoleColor(ConsoleColor.Cyan);

            Console.WriteLine("Menu Options:");
            
            Console.ResetColor();

            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select a choice from the menu: ");

            userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (userChoice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (userChoice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (userChoice == "4")
            {
                Console.WriteLine("Chau! (Bye in Argentinian Spanish)");
            }
            else
            {
                SetConsoleColor(ConsoleColor.Red);
                Console.WriteLine("\nYou may only pick a number from 1-4. Try again.");
                Console.ResetColor();
                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
        }
    }

    public static void SetConsoleColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}

