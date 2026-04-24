/* 
Author: Justin Hair

Sources:
- Starter from given student template
- GPT-4.1 to teach me string --> float conversion
- GPT-4.1 to teach me about var scopes within if statements

*/

using System;


class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("What is your grade?: ");
        float user_grade = float.Parse(Console.ReadLine());

        string pass_status = "ERROR";
        string letter = "ERROR";

        if (user_grade >= 90)
        {
            letter = "A";
        }
        else if (user_grade >= 80)
        {
            letter = "B";
        }
        else if (user_grade >= 70)
        {
            letter = "C";
        }
        else if (user_grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        if (user_grade < 70)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            pass_status = "FAIL";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            pass_status = "PASS";
        }

        Console.WriteLine($"\nCurrent grade is {user_grade}");
        Console.WriteLine($"\nWhich mean you have an {letter}");
        Console.WriteLine($"Class status: {pass_status}");

        Console.ForegroundColor = ConsoleColor.Black;
        if (pass_status == "PASS")
        {
            Console.WriteLine("Congrats! You passed the class!");
        }
        else
        {
            Console.WriteLine("You may be able to pass next time you take the class! Good luck!");
        }
    }
}