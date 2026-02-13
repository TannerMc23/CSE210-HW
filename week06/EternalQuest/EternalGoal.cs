public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent(int level)
    {
        int adjustedPoints = Points + (level * 5);
        return adjustedPoints;
    }

    public override string GetStatus()
    {
        return $"[∞] {Name}";
    }

    public override string Serialize()
    {
        return $"Eternal|{Name}|{Points}";
    }
}
