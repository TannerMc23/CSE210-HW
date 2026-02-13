public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent(int level)
    {
        if (!IsComplete)
        {
            IsComplete = true;

            // Increase difficulty scaling by level
            int adjustedPoints = Points + (level * 10);
            return adjustedPoints;
        }

        return 0;
    }

    public override string GetStatus()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name}";
    }

    public override string Serialize()
    {
        return $"Simple|{Name}|{Points}|{IsComplete}";
    }
}
