using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Goal
{
    public string Name { get; set; }
    public GoalType Type { get; set; }
    public int Value { get; set; }
    public int Progress { get; set; }
    public int Target { get; set; }
    public bool IsCompleted { get; set; }
}

enum GoalType
{
    Simple,
    Eternal,
    Checklist
}

class Program
{
    private static List<Goal> goals;
    private static int score;

    static void Main()
    {
        goals = new List<Goal>();
        score = 0;

        LoadData();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("==== Goal Tracker ====");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event (accomplished goal)");
            Console.WriteLine("3. Show list of goals");
            Console.WriteLine("4. Display score");
            Console.WriteLine("5. Edit a goal");
            Console.WriteLine("6. Delete a goal");
            Console.WriteLine("7. Save goals and score");
            Console.WriteLine("8. Exit");
            Console.WriteLine("======================");
            Console.Write("Enter your choice (1-8): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    EditGoal();
                    break;
                case "6":
                    DeleteGoal();
                    break;
                case "7":
                    SaveData();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("==== Create a new goal ====");
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple (Complete once, gain value)");
        Console.WriteLine("2. Eternal (Never complete, gain value on each record)");
        Console.WriteLine("3. Checklist (Complete multiple times, gain value each time and bonus on completion)");
        Console.Write("Enter the goal type (1-3): ");
        string goalTypeChoice = Console.ReadLine();

        GoalType goalType;
        if (!Enum.TryParse(goalTypeChoice, out goalType))
        {
            Console.WriteLine("Invalid goal type. Please try again.");
            return;
        }

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal value: ");
        string valueInput = Console.ReadLine();
        if (!int.TryParse(valueInput, out int value))
        {
            Console.WriteLine("Invalid goal value. Please try again.");
            return;
        }

        Goal goal;
        switch (goalType)
        {
            case GoalType.Simple:
                goal = new Goal
                {
                    Name = name,
                    Type = GoalType.Simple,
                    Value = value
                };
                break;
            case GoalType.Eternal:
                goal = new Goal
                {
                    Name = name,
                    Type = GoalType.Eternal,
                    Value = value
                };
                break;
            case GoalType.Checklist:
                Console.Write("Enter the goal target: ");
                string targetInput = Console.ReadLine();
                if (!int.TryParse(targetInput, out int target))
                {
                    Console.WriteLine("Invalid goal target. Please try again.");
                    return;
                }

                goal = new Goal
                {
                    Name = name,
                    Type = GoalType.Checklist,
                    Value = value,
                    Target = target
                };
                break;
            default:
                return;
        }

        goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent()
    {
        Console.WriteLine("==== Record an event ====");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            string goalInfo = $"{i + 1}. {status} {goal.Name}";

            if (goal.Type == GoalType.Checklist)
                goalInfo += $" (Completed {goal.Progress}/{goal.Target} times)";

            Console.WriteLine(goalInfo);
        }

        Console.Write("Enter the goal number: ");
        string goalNumberInput = Console.ReadLine();
        if (!int.TryParse(goalNumberInput, out int goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal number. Please try again.");
            return;
        }

        Goal selectedGoal = goals[goalNumber - 1];

        if (selectedGoal.Type == GoalType.Checklist && selectedGoal.Progress >= selectedGoal.Target)
        {
            Console.WriteLine("This goal has already been completed the required number of times.");
            return;
        }

        selectedGoal.Progress++;
        selectedGoal.IsCompleted = selectedGoal.Type switch
        {
            GoalType.Simple => true,
            GoalType.Eternal => false,
            GoalType.Checklist => selectedGoal.Progress >= selectedGoal.Target,
            _ => false,
        };

        score += selectedGoal.Value;

        Console.WriteLine("Event recorded successfully!");
    }

    static void ShowGoals()
    {
        Console.WriteLine("==== List of Goals ====");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            string goalInfo = $"{i + 1}. {status} {goal.Name}";

            if (goal.Type == GoalType.Checklist)
                goalInfo += $" (Completed {goal.Progress}/{goal.Target} times)";

            Console.WriteLine(goalInfo);
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    static void EditGoal()
    {
        Console.writeLine("==== Edit a Goal ===");
        if (goals.Count == 0)
        {
            Console.WriteLine("No Goals available.");
            return;
        }
        Console.WriteLine("Select a goal to edit:");
        ShowGoals();

        Console.Write("Enter the goal number: ");
        string goalNumberInput = Console.Readline();
        if (!int.TryParse(goalNumberInput, out int goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal number. Please try again.");
            return;
        }

        Goal selectedGoal = goals[goalNumber - 1];

        Console.WriteLine($"Editing goal: {selectedGoal.Name}");
        Console.WriteLine("Leave a field blank to keep the existing value.");

        Console.Write("Enter the new goal name: ");
        string newName = Console.ReadLine();
        if (!string.InNullOrEmpty(newName))
        {
            selectedGoal.Name = newName;
            Console.WriteLine("Goals name updated succesfully!");
        }

        Console.Write("Enter the new goal value: ");
        string newValueInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(newValueInput) && int.TryParse(newValueInput, out int NewValue))
        {
            selectedGoal.Value = NewValue;
            Console.WriteLine("Goal value updated successfully!");
        }

        if (selectedGoal.Type == GoalType.Checklist)
        {
            Console.Write("Enter the new goal target: ");
            string newTargetInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTargetInput) && int.TryParse(newTargetInput, out int newTarget))
            {
                selectedGoal.Target = newTarget;
                Console.WriteLine("Goal target updated successfully!");
            }
        }

        Console.WriteLine("Goal edited successfully!");
    }

    static void DeleteGoal()
    {
        Console.WriteLine("=== Delete a goal ===");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("select a goal to delete:");
        ShowGoals();

        Console.Write("Enter the goal number: ");
        string goalNumberInput = Console.ReadLine();
        if (!int.TryParse(goalNumberInput, out int goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.WriteLine("Invalid goal number. Please try again!");
            return;
        }

        Goal selectedGoal = goals[goalNumber -1];
        goals.Remove(selectedGoal);
        Console.WriteLine("Goal deleted successfully!");
    }

    static void SaveData()
    {
        string jsonData = JsonConvert.SerializeObject(goals, Formatting.Indented);
        File.WriteAllText("goals.json", jsonData);

        Console.WriteLine("Data saved successfully!");
    }

    static void LoadData()
    {
        if (File.Exists("goals.json"))
        {
            string jsonData = File.ReadAllText("goals.json");
            goals = JsonConvert.DeserializeObject<List<Goal>>(jsonData);
        }
    }
}
