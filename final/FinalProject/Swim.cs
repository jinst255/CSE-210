class Swim : Exercise
{
    double _distanceMeters;
    int metersPerLap = 50;
    public override double CalculateLoad()
    {
        return 0;    
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