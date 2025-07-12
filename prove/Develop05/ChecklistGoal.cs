public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonusPoints)
        : base(name, description, points)
    {
        this._targetCount = targetCount;
        this._currentCount = currentCount;
        this._bonusPoints = bonusPoints;
    }

    public override void RecordEvent(ref int score)
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            score += _points;
            if (_currentCount == _targetCount)
            {
                score += _bonusPoints;
            }
        }
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() =>
        $"[{_currentCount}/{_targetCount}]";

    public override string GetGoalType() => "ChecklistGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{_name}|{_description}|{_points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
}
