class RiskAssessor
{
    double _acuteLoad;
    double _chronicLoad;
    double _ACWR; // stands for "Acute Chronic Workload Ratio"
    string _riskLevel;
    double _avgSleepMins;
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
        Console.WriteLine($"Risk Level: NOT YET FINISHED");
    }
    public double GetACWR()
    {
        return _ACWR;
    }
}