using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        DisplayWelcome();

        string name = PromptUserName();

        int user_number = PromptUserNumber();

        PromtUserBirthYear(out int birth_year);

        int sqr_number = SquareNumber(user_number);

        DisplayResult(name, sqr_number, birth_year);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static void PromtUserBirthYear(out int birth_year)
    {
        Console.Write("Please enter the year you were born: ");
        birth_year = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int sqr_number, int birth_year)
    {
        Console.WriteLine($"{name}, the square of your number is {sqr_number}");
        Console.WriteLine($"{name}, you will turn {DateTime.Now.Year - birth_year} this year.");
    }
}
