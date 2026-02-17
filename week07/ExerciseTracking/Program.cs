// To exceed expectations I added in an extra method called GetCaloriesBurned() in the base class, Activity. This shows additional polymorphism and enhances the fitness tracking.

using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("17 Feb 2026", 30, 3.0));
        activities.Add(new Cycling("17 Feb 2026", 30, 6.0));
        activities.Add(new Swimming("17 Feb 2026", 30, 20));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}