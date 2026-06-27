class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int pointValue) : base(name, description, pointValue)
    {   }
    override public int RecordEvent()
    {
        return _pointValue;
    }
    override public string StringForFile()
    {
        return $"EternalGoal|{_name}|{_description}|{_pointValue}";
    }
    override public void DesconstructFromFile(string data)
    {
        string[] parts = data.Split('|');
        _name = parts[0];
        _description = parts[1];
        _pointValue = int.Parse(parts[2]);
    }
    override public string DisplayGoal()
    {
        return $"[--] {_name} ({_description})";
    }


}