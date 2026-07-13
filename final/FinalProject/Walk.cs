class Walk : Exercise
{
    private int _steps;
    public override double CalculateLoad()
    {
        return 0; 
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