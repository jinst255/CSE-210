using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // Console.Write("What is the magic number?: ");
        // int magic_number = int.Parse(Console.ReadLine());

        Console.WriteLine("The magic number is between 1 and 100");
        int magic_number = Random.Shared.Next(1, 101);

        int user_guess = 0;
        int guess_num = 0;
        
        while (user_guess != magic_number)
        {
            Console.Write("What is your guess?: ");
            user_guess = int.Parse(Console.ReadLine());


            if (user_guess < magic_number)
            {
                Console.WriteLine("Higher");
            }
            if (user_guess > magic_number)
            {
                Console.WriteLine("Lower");
            }

            guess_num ++;
        }
            
        Console.WriteLine($"You guessed it!\nIt only took you {guess_num} number of guesses!"); 




    }
}