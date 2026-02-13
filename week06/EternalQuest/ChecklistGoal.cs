public class ChecklistGoal : Goal
{
    private int timesCompleted;
    private int required;
    private int bonusPoints;

    public ChecklistGoal(string name, int points, int required, int bonus)
        : base(name, points)
    {
        this.required = required;
        bonusPoints = bonus;
        timesCompleted = 0;
    }

    public override int RecordEvent(int level)
    {
        if (!IsComplete)
        {
            timesCompleted++;

            int adjustedPoints = Points + (level * 10);

            if (timesCompleted >= required)
            {
                IsComplete = true;
                return adjustedPoints + bonusPoints;
            }

            return adjustedPoints;
        }

        return 0;
    }

    public override string GetStatus()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name} ({timesCompleted}/{required})";
    }

    public override string Serialize()
    {
        return $"Checklist|{Name}|{Points}|{timesCompleted}|{required}|{bonusPoints}";
    }
}
