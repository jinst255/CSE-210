using System;
using CsvHelper;
using System.Globalization;

/*
Todo:
- [x] Import real watch data and save it as data.csv (pick a simple column layout: date, activity type, duration, avg heart rate, sleep, distance/steps)
- [x] Build out all constructors for Run, Bike, Swim, Walk
- [x] Create .csv lodaer
- [x] build a  Run/Bike/Swim/Walk object from the csv data
- [x] Fill in CalculateLoad() in Run.cs with a real formula
- [x] Fill in CalculateLoad() in Bike.cs with a real formula
- [x] Fill in CalculateLoad() in Swim.cs with a real formula
- [x] Fill in CalculateLoad() in Walk.cs with a real formula
- [x] Test each child class individually with a few rows of real data to sanity-check CalculateLoad() output
- [x] In RiskAssessor, compute _acuteLoad from exercises in the last 7 days
- [x] In RiskAssessor, compute _chronicLoad from exercises in the last 28 days
- [x] Confirm ComputeACWR() returns a sensible number once real loads are set
- [x] Fill in AssessRisk() to bucket ACWR into a risk level string
- [x] Update program output to match the original app design

- [ ] Feed the load history into MLAnomalyDetector.Train()
- [ ] Fill in Detect() to flag when the latest load deviates from the trained history
- [ ] Replace placeholder Console.WriteLine values in Program.cs with real values from RiskAssessor/MLAnomalyDetector
- [ ] Run the full program end-to-end with real CSV data and check the output matches expectations
*/

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("This is my final project for CSE 210!");
        Console.WriteLine("I made this to help prevent future personal injuries.\n");

        Console.Write("Enter the path to the .csv: ");
        string pathToCSV = Console.ReadLine();
        List<Exercise> listOfExercises = ImportCSV(pathToCSV);


        // Load Data from CSV
        Console.WriteLine("Loading in data...\n");
        DateTime mostRecentDate = listOfExercises.Min(e => e.GetDate()); // cool lambda function to extract the lastest date in the data

        Console.WriteLine($"Data since: {mostRecentDate.ToShortDateString()}"); 


        // Calculate ACWR and Risk
        RiskAssessor riskAssessor = new RiskAssessor();
        riskAssessor.ComputeLoads(listOfExercises);
        double ACWR = riskAssessor.ComputeACWR();

        Console.WriteLine($"Acute Load  (7-day): {riskAssessor.GetAcuteLoad()}");
        Console.WriteLine($"Chronic Load (28-day): {riskAssessor.GetChronicLoad()}");
        Console.WriteLine($"ACWR: {ACWR}\n");

        riskAssessor.AssessRisk();



        // Detect Anomalies
        MLAnomalyDetector ML = new MLAnomalyDetector();
        ML.PrintMLAnomalyReport();

    }
    public static List<Exercise> ImportCSV(string _pathToCSV)
    {
        Console.WriteLine($"Importing CSV from {_pathToCSV}...");
        using var reader = new StreamReader(_pathToCSV);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        // prep the header and init the list of Exercise object
        csv.Read();
        csv.ReadHeader();
        List<Exercise> listOfExercises = new List<Exercise>();


        while (csv.Read())
        {
            // Read data from each row in .csv file
            DateTime date = csv.GetField<DateTime>("date");
            int duration = csv.GetField<int>("duration_mins");
            double avgHeartRate = csv.GetField<double>("avg_heart_rate");
            int sleep = csv.GetField<int>("sleep_mins");
            string activityType = csv.GetField("activity_type");

            // Debug line to make sure the .csv is loading properly.
            // Console.WriteLine($"Date: {date}, Duration: {duration}, Avg HR: {avgHeartRate}, Sleep: {sleep}, Activity Type: {activityType}");

            // Add any aplicable vars, then make each row an Exercise object
            if (activityType == "Walk")
            {
                int steps = csv.GetField<int>("steps");
                listOfExercises.Add(new Walk(date, duration, avgHeartRate, sleep, steps));
            }
            if (activityType == "Run")
            {
                float distanceMiles = csv.GetField<float>("distance_miles");
                listOfExercises.Add(new Run(date, duration, avgHeartRate, sleep, distanceMiles));
            }
            if (activityType == "Bike")
            {
                float distanceMiles = csv.GetField<float>("distance_miles");
                listOfExercises.Add(new Bike(date, duration, avgHeartRate, sleep, distanceMiles));
            }
            if (activityType == "Swim")
            {
                float distanceMeters = csv.GetField<float>("distance_meters");
                listOfExercises.Add(new Swim(date, duration, avgHeartRate, sleep, distanceMeters));
            }
        }

        return listOfExercises;
    }

}