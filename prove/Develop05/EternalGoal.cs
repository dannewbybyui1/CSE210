public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent(ref int score)
    {
        score += points;
    }

    public override bool IsComplete() => false;

    public override string GetStatus() => "[∞]";

    public override string GetGoalType() => "EternalGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{name}|{description}|{points}";
}
