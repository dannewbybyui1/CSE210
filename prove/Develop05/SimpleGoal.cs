public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        this.isComplete = isComplete;
    }

    public override void RecordEvent(ref int score)
    {
        if (!isComplete)
        {
            isComplete = true;
            score += points;
        }
    }

    public override bool IsComplete() => isComplete;

    public override string GetStatus() => isComplete ? "[X]" : "[ ]";

    public override string GetGoalType() => "SimpleGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{name}|{description}|{points}|{isComplete}";
}
