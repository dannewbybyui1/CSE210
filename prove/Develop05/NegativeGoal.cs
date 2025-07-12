public class NegativeGoal : Goal
{
    private bool _triggered;

    public NegativeGoal(string name, string description, int points, bool triggered = false)
        : base(name, description, points)
    {
        this._triggered = triggered;
    }

    public override void RecordEvent(ref int score)
    {
        if (!_triggered)
        {
            score -= _points;
            _triggered = true;
        }
    }

    public override bool IsComplete() => _triggered;

    public override string GetStatus() => _triggered ? "[X BAD]" : "[!BAD!]";

    public override string GetGoalType() => "NegativeGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{_name}|{_description}|{_points}|{_triggered}";
}
