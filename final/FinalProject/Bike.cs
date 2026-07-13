class Bike : Exercise
{
    private double _distancesMiles;
    public override double CalculateLoad()
    {
        return 0; 
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