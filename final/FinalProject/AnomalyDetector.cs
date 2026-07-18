class AnomalyDetector
{
    // I decided to use a tuple here to store both the date and the load for any given anomaly
    List<(DateTime, double)> anomalySpikes = new List<(DateTime, double)>(); 
    double _mean;
    double _stdDev;
    /*
    needed:
    - [x] Earliest date in data
    - [x] Latest date in data (so it know how to calculate mean correctly)
    - [x] Get mean of data
    - [x] Get std dev of data
    - [x] If any singular data point is +- 2 std devs from the mean, save it to spikes
    */
    public void CalculateMeanAndStdDev(List<Exercise> exercises)
    {
        // add all data points together
        foreach (double dailyLoad in exercises.Select(e => e.CalculateLoad()))
        {
            _mean += dailyLoad;
        }

        // divide total by the amount of days in the data (latest date - earliest date)
        DateTime latest = Exercise.GetMostRecentDate(exercises);
        DateTime earliest = Exercise.GetEarliestDate(exercises);
        _mean /= (latest - earliest).Days;

        // calculate std dev
        double sumOfSquares = 0;
        
        foreach (double dailyLoad in exercises.Select(e => e.CalculateLoad()))
        {
            sumOfSquares += Math.Pow(dailyLoad - _mean, 2);
        }

        _stdDev = Math.Sqrt(sumOfSquares / (latest - earliest).Days);
    }
    public double GetMean()
    {
        return _mean;
    }
    public double GetStdDev()
    {
        return _stdDev;
    }



    public void FindAnomalies(List<Exercise> exercises)
    {

        foreach ((DateTime date, double load) in exercises.Select(e => (e.GetDate(), e.CalculateLoad())))
        {
            if (Math.Abs(load - _mean) > 2 * _stdDev)
            {
                anomalySpikes.Add((date, load));
            }
        }
        
    }
    public List<(DateTime, double)> GetAnomalies()
    {
        return anomalySpikes;
    }
    public void PrintAnomalyReport()
    {
        if (anomalySpikes.Count == 0)
        {
            Console.WriteLine("- No anomalies detected.");
        }
        else
        {
            Console.WriteLine($"Total anomalies detected: {anomalySpikes.Count}");
            foreach ((DateTime date, double load) in anomalySpikes)
            {
                Console.WriteLine($"- Date: {date.ToShortDateString()}\n  Load: {load}\n\n");
            }
            Console.WriteLine();
        }
    }
}