using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        Fraction f = new Fraction(5);
        // f.SetTop(1);
        // f.SetBottom(2);
        Console.WriteLine($"The fraction is: {f.GetFractionString()}");
        Console.WriteLine($"The decimal value is: {f.GetDecimalValue()}");
        */

        // initiate the fraction and random number generator
        Fraction myFraction = new Fraction();
        Random random = new Random();

        for (int i = 0; i < 25; i++)
        {
            // Get 2 random ints
            int randTop = random.Next(1, 11);
            int randBottom = random.Next(1, 11);

            // Set the fraction values
            myFraction.SetTop(randTop);
            myFraction.SetBottom(randBottom);

            // Get the string and double version of our fraction and print it out
            string fracString = myFraction.GetFractionString();
            double decimalValue = myFraction.GetDecimalValue();
            Console.WriteLine($"Fraction 1: string: {fracString} Number: {decimalValue}");
        }

    }
}




