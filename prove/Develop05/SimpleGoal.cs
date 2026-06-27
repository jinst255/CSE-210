class SimpleGoal : Goal
{
    bool _isComplete;
    public SimpleGoal(string name, string description, int pointValue) : base(name, description, pointValue)
    {
        _isComplete = false; 
    }
    override public int RecordEvent()
    {
        if (_isComplete) // This stops the user from getting infinite points
        {
            return 0;
        }

        _isComplete = true;
        return _pointValue;
    }
    override public string StringForFile()
    {
        return $"SimpleGoal|{_name}|{_description}|{_pointValue}|{_isComplete}"; 
    }
    override public void DesconstructFromFile(string data)
    {
        string[] parts = data.Split('|');
        _name = parts[0];
        _description = parts[1];
        _pointValue = int.Parse(parts[2]);
        _isComplete = bool.Parse(parts[3]);
    }
    override public string DisplayGoal()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";
    }
}