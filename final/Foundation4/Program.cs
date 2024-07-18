using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create activities
        Activity running = new Running("2024-07-18", 30, 3.0); // 3 miles
        Activity cycling = new Cycling("2024-07-18", 45, 15.0); // 15 mph
        Activity swimming = new Swimming("2024-07-18", 60, 20); // 20 laps

        // Store activities in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display activity summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

abstract class Activity
{
    private string date;
    private int duration; // in minutes

    public Activity(string date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public string Date => date;
    public int Duration => duration;

    public abstract double GetDistance(); // in miles or km
    public abstract double GetSpeed(); // in mph or kph
    public abstract double GetPace(); // in minutes per mile or km

    public virtual string GetSummary()
    {
        return $"{date} {GetType().Name} ({duration} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

class Running : Activity
{
    private double distance; // in miles

    public Running(string date, int duration, double distance)
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Duration) * 60; // mph
    }

    public override double GetPace()
    {
        return Duration / distance; // min per mile
    }
}

class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(string date, int duration, double speed)
        : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Duration) / 60; // miles
    }

    public override double GetSpeed()
    {
        return speed; // mph
    }

    public override double GetPace()
    {
        return 60 / speed; // min per mile
    }

    public override string GetSummary()
    {
        return $"{Date} Cycling ({Duration} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

class Swimming : Activity
{
    private int laps;
    private const double LapLengthInMeters = 50;
    private const double MetersToMilesConversion = 0.000621371;

    public Swimming(string date, int duration, int laps)
        : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * LapLengthInMeters * MetersToMilesConversion; // miles
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60; // mph
    }

    public override double GetPace()
    {
        return Duration / GetDistance(); // min per mile
    }

    public override string GetSummary()
    {
        return $"{Date} Swimming ({Duration} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
