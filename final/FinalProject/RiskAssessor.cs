class RiskAssessor
{
    double _acuteLoad;
    double _chronicLoad;
    double _ACWR; // stands for "Acute Chronic Workload Ratio"
    string _riskLevel;
    double _avgSleepMins;

    public void ComputeLoads(List<Exercise> exercises)
    {
        DateTime mostRecentDate = exercises.Max(e => e.GetDate()); // cool lambda function to extract the lastest date in the data

        double acuteSum = 0;
        double chronicSum = 0;

        foreach (Exercise ex in exercises)
        {
            int daysAgo = (mostRecentDate - ex.GetDate()).Days;

            if (daysAgo <= 6)
            {
                acuteSum += ex.CalculateLoad();
            }
            if (daysAgo <= 27)
            {
                chronicSum += ex.CalculateLoad();
            }
        }

        _acuteLoad = acuteSum / 7;
        _chronicLoad = chronicSum / 28;
    }
    public double GetAcuteLoad()
    {
        return _acuteLoad;
    }
    public double GetChronicLoad()
    {
        return _chronicLoad;
    }
    public double ComputeACWR()
    {
        if (_chronicLoad == 0) // This stops /0 error
        {
            return 0; 
        }

        _ACWR = _acuteLoad / _chronicLoad;
        return _ACWR;
    }
    public void AssessRisk()
    {
        if (_ACWR < 1.3)
        {
            _riskLevel = "Low — training load is balanced.";
        }
        else if (_ACWR < 1.8)
        {
            _riskLevel = "Medium — approaching the injury danger zone. Consider a lighter week.";
        }
        else
        {
            _riskLevel = "High — training load is imbalanced. Reduce training intensity or you will likley be injured.";
        }

        Console.WriteLine($"Risk Level: {_riskLevel}\n"); 
    }
    public double GetACWR()
    {
        return _ACWR;
    }
}