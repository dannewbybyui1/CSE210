using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public string GetName() { return _name; }
    public string GetDescription() { return _description; }

    public Goal(string name, string description, int points)
    {
        this._name = name;
        this._description = description;
        this._points = points;
    }

    public abstract void RecordEvent(ref int score);
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string GetGoalType();
    public abstract string SaveData();

    public static Goal LoadData(string line)
    {
        string[] parts = line.Split('|');
        string type = parts[0];

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            case "NegativeGoal":
                return new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            default:
                throw new Exception("Invalid goal type.");
        }
    }
}
