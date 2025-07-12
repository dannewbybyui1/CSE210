public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        this._isComplete = isComplete;
    }

    public override void RecordEvent(ref int score)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            score += _points;
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() => _isComplete ? "[X]" : "[ ]";

    public override string GetGoalType() => "SimpleGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{_name}|{_description}|{_points}|{_isComplete}";
}
