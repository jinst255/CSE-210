abstract class Exercise
{
    protected DateTime _date;
    protected int _durationMins;
    protected double _avgHeartRate;
    protected int _sleepMins;

    public Exercise(DateTime date, int durationMins, double avgHeartRate, int sleepMins)
    {
        _date = date;
        _durationMins = durationMins;
        _avgHeartRate = avgHeartRate;
        _sleepMins = sleepMins;
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

    public static DateTime GetMostRecentDate(List<Exercise> exercises)
    {
        return exercises.Max(e => e.GetDate());
    }
    public static DateTime GetEarliestDate(List<Exercise> exercises)
    {
        return exercises.Min(e => e.GetDate());
    }
}
