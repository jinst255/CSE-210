abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _pointValue;

    public Goal(string name, string description, int pointValue)
    {
        _name = name;
        _description = description;
        _pointValue = pointValue;
    }

    abstract public int RecordEvent();
    abstract public string StringForFile();
    abstract public void DesconstructFromFile(string data);
    abstract public string DisplayGoal();

    protected string DisplayName()
    {
        return _name;
    }
    
}