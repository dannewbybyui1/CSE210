public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonusPoints)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.currentCount = currentCount;
        this.bonusPoints = bonusPoints;
    }

    public override void RecordEvent(ref int score)
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            score += points;
            if (currentCount == targetCount)
            {
                score += bonusPoints;
            }
        }
    }

    public override bool IsComplete() => currentCount >= targetCount;

    public override string GetStatus() =>
        $"[{currentCount}/{targetCount}]";

    public override string GetGoalType() => "ChecklistGoal";

    public override string SaveData() =>
        $"{GetGoalType()}|{name}|{description}|{points}|{targetCount}|{currentCount}|{bonusPoints}";
}
