public class NegativeGoal : Goal
{
    private bool triggered;

    public NegativeGoal(string name, string description, int points, bool triggered = false)
        : base(name, description, points)
    {
        this.triggered = triggered;
    }

    public override void RecordEvent(ref int score)
    {
        if (!triggered)
        {
            score -= points;
            triggered = true;
        }
    }

    public override bool IsComplete() => triggered;

    public override string GetStatus() => triggered ? "[X BAD]" : "[!BAD!]";

    public override string GetGoalType() => "NegativeGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{name}|{description}|{points}|{triggered}";
}
