class MLAnomalyDetector()
{
    List<double> _loadHistory;
    bool _anomalyDetected;
    double _anomalyScore;
    public void Train()
    {
        
    }
    public bool Detect()
    {
        return false; // Not yet finished
    }
    public double GetAnomalyScore()
    {
        return _anomalyScore;
    }
    public void PrintMLAnomalyReport()
    {
        if (_anomalyDetected)
        {
            Console.WriteLine($"A load spike has been detected. Try to be more consistent with your activity levels. \nYour anomaly score is {_anomalyScore}");
        }
        else
        {
            Console.WriteLine($"It looks like your activity levels are consistent!");
        }
    }
}