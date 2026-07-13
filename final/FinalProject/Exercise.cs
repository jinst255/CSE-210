abstract class Exercise
{
    public DateTime _date;
    public int _durationMins;
    public double _avgHeartRate;
    public int _sleepMins;

    public Exercise()
    {

    }
    public abstract double CalculateLoad();

    public DateTime GetDate()
    {
        return _date;
    }
    public int GetDuration()
    {
        return _durationMins;
    }
    public abstract string GetActivityType();
}
