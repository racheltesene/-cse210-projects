using System;
using System.Collections.Generic;

// Base class for goals
public abstract class Goal
{
    private string name;
    private int points;

    public Goal(string name)
    {
        this.name = name;
        points = 0;
    }

    public string GetName()
    {
        return name;
    }

    public int GetPoints()
    {
        return points;
    }

    public void SetPoints(int value)
    {
        points = value;
    }

    public abstract void Complete();

    public abstract string GetProgress();
}

// Simple goal class
public class SimpleGoal : Goal
{
    private int rewardPoints;

    public SimpleGoal(string name, int rewardPoints) : base(name)
    {
        this.rewardPoints = rewardPoints;
    }

    public override void Complete()
    {
        SetPoints(GetPoints() + rewardPoints);
    }

    public override string GetProgress()
    {
        return "Completed: " + (GetPoints() > 0 ? "Yes" : "No");
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    private int rewardPoints;

    public EternalGoal(string name, int rewardPoints) : base(name)
    {
        this.rewardPoints = rewardPoints;
    }

    public override void Complete()
    {
        SetPoints(GetPoints() + rewardPoints);
    }

    public override string GetProgress()
    {
        return "Eternal Goal - Points: " + GetPoints();
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    private int completionTarget;
    private int completionCount;

    public ChecklistGoal(string name, int completionTarget, int rewardPoints) : base(name)
    {
        this.completionTarget = completionTarget;
        this.completionCount = 0;
        SetPoints(0);
    }

    public override void Complete()
    {
        completionCount++;
        SetPoints(GetPoints() + (completionCount == completionTarget ? completionTarget * 50 : 0));
    }

    public override string GetProgress()
    {
        return "Completed " + completionCount + "/" + completionTarget + " times";
    }
}

// Main program
class Program
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>();

        Console.WriteLine("Welcome to the Eternal Quest Program!");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. View progress");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGoal(goals);
                    break;
                case "2":
                    RecordEvent(goals);
                    break;
                case "3":
                    ViewProgress(goals);
                    break;
                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }

    static void AddGoal(List<Goal> goals)
    {
        Console.WriteLine("\nChoose the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string goalType = Console.ReadLine();

        Console.Write("Enter the name of the goal: ");
        string goalName = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                Console.Write("Enter the reward points for completing the goal: ");
                int rewardPoints = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(goalName, rewardPoints));
                Console.WriteLine("Simple Goal added successfully!");
                break;
            case "2":
                Console.Write("Enter the reward points for completing the goal: ");
                int eternalRewardPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(goalName, eternalRewardPoints));
                Console.WriteLine("Eternal Goal added successfully!");
                break;
            case "3":
                Console.Write("Enter the completion target for the checklist goal: ");
                int completionTarget = int.Parse(Console.ReadLine());
                Console.Write("Enter the reward points for completing each checklist item: ");
                int checklistRewardPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(goalName, completionTarget, checklistRewardPoints));
                Console.WriteLine("Checklist Goal added successfully!");
                break;
            default:
                Console.WriteLine("Invalid goal type. Please choose a valid option.");
                break;
        }
    }

    static void RecordEvent(List<Goal> goals)
    {
        Console.WriteLine("\nChoose a goal to record an event:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].Complete();
            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection. Please choose a valid goal.");
        }
    }

    static void ViewProgress(List<Goal> goals)
    {
        Console.WriteLine("\nYour Current Progress:");

        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetName() + ": " + goal.GetProgress() + " - Points: " + goal.GetPoints());
        }
    }
}
