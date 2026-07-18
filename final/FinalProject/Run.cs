class Run : Exercise
{
    private double _distanceMiles;

    public Run(DateTime date, int durationMins, double avgHeartRate, int sleepMins, double distanceMiles) : base(date, durationMins, avgHeartRate, sleepMins)
    {
        _distanceMiles = distanceMiles;
    }
    public override double CalculateLoad()
    {
        double baseLoad = _durationMins * _avgHeartRate / 100; // duration * heart rate as a base intensity score
        return baseLoad * 1.5 + _distanceMiles * 3; // running is higher stress on the body so I up'd the multiplier
    }
    public override string GetActivityType()
    {
        return "Running"; 
    }
    public double GetDistance()
    {
        return _distanceMiles; 
    }
}