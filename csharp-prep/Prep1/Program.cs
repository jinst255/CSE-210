/* 
Author: Justin Hair

Sources:
Starter code from template on main github repo

I learned the most from the video provided at: 
https://byui-cse.github.io/cse210-course-2023/unit01/csharp-1.html
As well as by asking GPT-4.1 general questions about C#

I also messed around with Console.Beep() but found it didnt work on linux. 
*/


using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();
        
        Console.Write($"\nYour name is ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{last_name}, {first_name} {last_name}."); 
    }
}