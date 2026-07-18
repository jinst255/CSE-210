class Walk : Exercise
{
    private int _steps;
    public Walk(DateTime date, int durationMins, double avgHeartRate, int sleepMins, int steps) : base(date, durationMins, avgHeartRate, sleepMins)
    {
        _steps = steps; 
    }
    public override double CalculateLoad()
    {
        double baseLoad = _durationMins * _avgHeartRate / 100; // duration * heart rate as a base intensity score
        return baseLoad * 1.0 + _steps / 2000.0; // walking is low impact so it keeps the base multiplier, steps add a small volume bump
    }
    public override string GetActivityType()
    {
        return "Walking"; 
    }
    public int GetSteps()
    {
        return _steps; 
    }
}