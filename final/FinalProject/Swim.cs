class Swim : Exercise
{
    double _distanceMeters;
    public Swim(DateTime date, int durationMins, double avgHeartRate, int sleepMins, double distanceMeters) : base(date, durationMins, avgHeartRate, sleepMins)
    {
        _distanceMeters = distanceMeters;
    }
    int metersPerLap = 50;
    public override double CalculateLoad()
    {
        double baseLoad = _durationMins * _avgHeartRate / 100; // duration * heart rate as a base intensity score
        return baseLoad * 1.0 + GetLaps() * 0.5; // swimming is no-impact so it keeps the base multiplier, laps add volume
    }
    public override string GetActivityType()
    {
        return "Swimming"; 
    }
    public int GetLaps()
    {
        return (int)(_distanceMeters / metersPerLap);
    }
}