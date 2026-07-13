using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("This is my final project for CSE 210!");
        Console.WriteLine("I made this to help prevent future personal injuries.\n");

        Console.Write("Enter the path to the .csv: ");
        string pathToCSV = Console.ReadLine();
        // Console.WriteLine($"PATH: {pathToCSV}");


        // Load Data from CSV
        Console.WriteLine("Loading in data...");
        Console.WriteLine($"Data since: NOT YET FINISHED");

        // Calculate ACWR and Risk
        RiskAssessor riskAssessor = new RiskAssessor();
        double ACWR = riskAssessor.ComputeACWR();

        Console.WriteLine($"Acute Load  (7-day): {-1}");
        Console.WriteLine($"Chronic Load (28-day): {-1}");

        Console.WriteLine($"ACWR: {ACWR}");

        Console.WriteLine($"Risk Level: {-1}\n"); // part of RiskAssessor

        // Detect Anomalies
        MLAnomalyDetector ML = new MLAnomalyDetector();
        ML.PrintMLAnomalyReport();

    }
}

