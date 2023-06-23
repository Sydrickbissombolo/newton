using System;
using System.Collections.Generic;

public enum GoalType
{
    Simple,
    Eternal,
    Checklist
}

public abstract class Goal
{
    private string name;
    private GoalType type;
    private int value;
    private int progress;
    private int target;
    private bool isCompleted;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public GoalType Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public int Progress
    {
        get { return progress; }
        set { progress = value; }
    }

    public int Target
    {
        get { return target; }
        set { target = value; }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

    public abstract void Display();

    public virtual void UpdateProgress(int value)
    {
        progress += value;
        if (progress >= target)
        {
            progress = target;
            isCompleted = true;
        }
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int target, int value)
    {
        Name = name;
        Type = GoalType.Simple;
        Target = target;
        Value = value;
    }

    public override void Display()
    {
        Console.WriteLine("Simple Goal:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Progress: {Progress}/{Target}");
        Console.WriteLine($"Value: {Value}");
        Console.WriteLine($"Completed: {IsCompleted}");
        Console.WriteLine();
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int target, int value)
    {
        Name = name;
        Type = GoalType.Eternal;
        Target = target;
        Value = value;
    }

    public override void Display()
    {
        Console.WriteLine("Eternal Goal:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Progress: {Progress}/{Target}");
        Console.WriteLine($"Value: {Value}");
        Console.WriteLine($"Completed: {IsCompleted}");
        Console.WriteLine();
    }
}

public class ChecklistGoal : Goal
{
    private int requiredTimes;

    public ChecklistGoal(string name, int target, int value, int requiredTimes)
    {
        Name = name;
        Type = GoalType.Checklist;
        Target = target;
        Value = value;
        this.requiredTimes = requiredTimes;
    }

    public override void Display()
    {
        Console.WriteLine("Checklist Goal:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Progress: {Progress}/{Target} (Required: {requiredTimes})");
        Console.WriteLine($"Value: {Value}");
        Console.WriteLine($"Completed: {IsCompleted}");
        Console.WriteLine();
    }

    public override void UpdateProgress(int value)
    {
        base.UpdateProgress(value);
        if (progress >= target * requiredTimes)
        {
            progress = target * requiredTimes;
            isCompleted = true;
        }
    }
}

public class Program
{
    private List<Goal> goals;
    private int score;

    public Program()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void CreateGoal(string name, GoalType type, int target, int value, int requiredTimes = 0)
    {
        Goal goal;
        switch (type)
        {
            case GoalType.Simple:
                goal = new SimpleGoal(name, target, value);
                break;
            case GoalType.Eternal:
                goal = new EternalGoal(name, target, value);
                break;
            case GoalType.Checklist:
                goal = new ChecklistGoal(name, target, value, requiredTimes);
                break;
            default:
                throw new ArgumentException("Invalid goal type.");
        }

        goals.Add(goal);
    }

    public void RecordEvent(string goalName, int value)
    {
        Goal goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.UpdateProgress(value);
            score += goal.Value;
        }
    }

    public void ShowGoals()
    {
        foreach (Goal goal in goals)
        {
            goal.Display();
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {score}");
    }

    public void SaveData()
    {
        // Implementation to save goals and score data to a file
        Console.WriteLine("Data saved.");
    }

    public void LoadData()
    {
        // Implementation to load goals and score data from a file
        Console.WriteLine("Data loaded.");
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Program program = new Program();

        program.CreateGoal("Simple Goal", GoalType.Simple, 10, 5);
        program.CreateGoal("Eternal Goal", GoalType.Eternal, 20, 10);
        program.CreateGoal("Checklist Goal", GoalType.Checklist, 5, 2, 3);

        program.ShowGoals();

        program.RecordEvent("Simple Goal", 7);
        program.RecordEvent("Eternal Goal", 12);
        program.RecordEvent("Checklist Goal", 2);
        program.RecordEvent("Checklist Goal", 2);
        program.RecordEvent("Checklist Goal", 2);

        program.ShowGoals();

        program.DisplayScore();

        program.SaveData();
        program.LoadData();
    }
}
