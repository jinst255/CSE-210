class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _repsGoal;
    private int _repsCount;

    public ChecklistGoal(string name, string description, int pointValue, int bonusPoints, int repsGoal) : base(name, description, pointValue)
    {
        _bonusPoints = bonusPoints;
        _repsGoal = repsGoal;
    }
    override public int RecordEvent()
    {
        _repsCount++;
        if (_repsCount == _repsGoal)
        {
            return _pointValue + _bonusPoints;
        }
        return _pointValue;
    }
    override public string StringForFile()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_pointValue}|{_bonusPoints}|{_repsGoal}|{_repsCount}";
    }
    override public void DesconstructFromFile(string data)
    {
        string[] parts = data.Split('|');
        _name = parts[0];
        _description = parts[1];
        _pointValue = int.Parse(parts[2]);
        _bonusPoints = int.Parse(parts[3]);
        _repsGoal = int.Parse(parts[4]);
        _repsCount = int.Parse(parts[5]);
    }
    override public string DisplayGoal()
    {
        bool complete = _repsCount >= _repsGoal;
        return $"[{(complete ? "X" : " ")}] {_name} ({_description}) -- Currently completed: {_repsCount}/{_repsGoal}";
    }

}