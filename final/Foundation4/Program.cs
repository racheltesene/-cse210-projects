using System;
using System.Collections.Generic;

// Base Activity class
public class Activity
{
    private DateTime date;
    protected int durationInMinutes;

    public Activity(DateTime date, int durationInMinutes)
    {
        this.date = date;
        this.durationInMinutes = durationInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0.0; // Default implementation for activities without distance
    }

    public virtual double GetSpeed()
    {
        return 0.0; // Default implementation for activities without speed
    }

    public virtual double GetPace()
    {
        return 0.0; // Default implementation for activities without pace
    }

    public string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({durationInMinutes} min) - Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int durationInMinutes, double distance)
        : base(date, durationInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (durationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationInMinutes / distance;
    }
}

// Derived class for Stationary Bicycles
public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int durationInMinutes, double speed)
        : base(date, durationInMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed; // Pace is in minutes per mile, as speed is in miles per hour
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationInMinutes, int laps)
        : base(date, durationInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1000.0; // Convert laps to kilometers (1 lap = 50 meters)
    }

    public override double GetSpeed()
    {
        return GetDistance() / (durationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return durationInMinutes / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        // Create activities
        var runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        var cyclingActivity = new Cycling(new DateTime(2022, 11, 3), 30, 15.0);
        var swimmingActivity = new Swimming(new DateTime(2022, 11, 3), 30, 20);

        // Put activities in a list
        List<Activity> activities = new List<Activity>
        {
            runningActivity,
            cyclingActivity,
            swimmingActivity
        };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
