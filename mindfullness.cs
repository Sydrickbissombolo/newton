using System;
using System.Threading;

class Activity
{
    protected string activityName;
    protected int duration;

    public Activity(string name)
    {
        activityName = name;
    }

    protected void StartActivity(string description)
    {
        Console.WriteLine($"Starting {activityName}...");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(2000); // Pause for a few seconds
    }

    protected void EndActivity()
    {
        Console.WriteLine("\nGood job! You have completed the activity.");
        Console.WriteLine($"Activity: {activityName}");
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(2000);
    }

    protected void Countdown()
    {
        for (int i = duration; i > 0; i--)
        {
            Console.Write($"Countdown: {i}");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - $"Countdown: {i}".Length, Console.CursorTop);
        }
        Console.WriteLine();
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing Activity")
    {
        this.duration = duration;
    }

    public void PerformActivity()
    {
        StartActivity("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Countdown();

        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breath in...");
            Thread.Sleep(2000);
            ShowSpinner();
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000);
            ShowSpinner();
        }

        EndActivity();
    }
}

class ReflectionActivity : Activity
{
    public ReflectionActivity(int duration) : base("Reflection Activity")
    {
        this.duration = duration;
    }

    public void PerformActivity()
    {
        StartActivity("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Countdown();

        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was completed?",
            "What made this time different than other times when you were not successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random random = new Random();

        while (true)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(2000);
            ShowSpinner();

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000);
                ShowSpinner();
            }

            Console.Write("Press Enter to continue or 'Q' to quit: ");
            string response = Console.ReadLine();
            if (response.ToLower() == "q")
                break;
        }

        EndActivity();
    }
}

class ListingActivity : Activity
{
    public ListingActivity(int duration) : base("Listing Activity")
    {
        this.duration = duration;
    }

    public void PerformActivity()
    {
        StartActivity("This activity will help you reflect on the good things in your life by having a list as you can in a certain area.");
        Countdown();

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are the people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000);
        ShowSpinner();

        int count = 0;
        while (true)
        {
            Console.Write("Enter an item (or 'Q' to finish): ");
            string item = Console.ReadLine();
            if (item.ToLower() == "q")
                break;
            count++;
        }

        Console.WriteLine($"\nNumber of items entered: {count}");
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine("Enter your choice (1 - 4)");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                int duration = GetDurationFromUser();
                BreathingActivity breathingActivity = new BreathingActivity(duration);
                breathingActivity.PerformActivity();
            }
            else if (choice == "2")
            {
                int duration = GetDurationFromUser();
                ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.PerformActivity();
            }
            else if (choice == "3")
            {
                int duration = GetDurationFromUser();
                ListingActivity listingActivity = new ListingActivity(duration);
                listingActivity.PerformActivity();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again!");
            }

            Console.WriteLine();
        }
    }

    static int GetDurationFromUser()
    {
        Console.Write("Enter duration in seconds: ");
        string durationStr = Console.ReadLine();
        int duration;
        while (!int.TryParse(durationStr, out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive integer");
            Console.Write("Enter duration in seconds: ");
            durationStr = Console.ReadLine();
        }
        return duration;
    }

    static void ShowSpinner()
    {
        char[] spinchars = { '|', '/', '-', '\\' };
        for (int i = 0; i < 4; i++)
        {
            foreach (char c in spinchars)
            {
                Console.Write(c);
                Thread.Sleep(2000);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
        }
    }

    static void Countdown()
    {
        // Remaining code for Countdown method
    }

    static void EndActivity()
    {
        // Remaining code for EndActivity method
    }
}
