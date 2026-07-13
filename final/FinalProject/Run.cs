class Run : Exercise
{
    private double _distanceMiles;
    public override double CalculateLoad()
    {
        return 0; 
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