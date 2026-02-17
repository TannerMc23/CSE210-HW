using System;

public class Activity
{
    protected string _date;
    protected int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual double GetCaloriesBurned()
    {
        return 0;
    }

    public string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.00} miles, " +
               $"Speed: {GetSpeed():0.00} mph, " +
               $"Pace: {GetPace():0.00} min per mile, " +
               $"Calories: {GetCaloriesBurned():0}";
    }
}