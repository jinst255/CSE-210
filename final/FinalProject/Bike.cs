class Bike : Exercise
{
    private double _distancesMiles;
    public Bike(DateTime date, int durationMins, double avgHeartRate, int sleepMins, double distancesMiles) : base(date, durationMins, avgHeartRate, sleepMins)
    {
        _distancesMiles = distancesMiles;
    }
    public override double CalculateLoad()
    {
        double baseLoad = _durationMins * _avgHeartRate / 100; // duration * heart rate as a base intensity score
        return baseLoad * 0.8 + _distancesMiles * 1.5; // biking is low impact/seated so the base is discounted, distance adds moderate volume
    }
    public override string GetActivityType()
    {
        return "Biking"; 
    }
    public double GetDistance()
    {
        return _distancesMiles; 
    }
}