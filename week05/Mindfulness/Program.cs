using System;
using System.Collections.Generic;

public abstract class Activity
{
    private string activityName;
    private string description;
    private int duration;

    public Activity(string activityName, string description)
    {
        this.activityName = activityName;
        this.description = description;
    }

    public string ActivityName { get { return activityName; } set { activityName = value; } }
    public string Description { get { return description; } set { description = value; } }
    public int Duration { get { return duration; } set { duration = value; } }

    public abstract void StartActivity();

    public void ShowAnimation()
    {
        Console.Write("Loading");
        for (int i = 0; i < 3; i++)
        {
            System.Threading.Thread.Sleep(500);
            Console.Write(".");
        }
        Console.WriteLine();
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        ShowAnimation();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.")
    { }

    public override void StartActivity()
    {
        Console.WriteLine($"{ActivityName}: {Description}");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        Duration = duration;

        ShowAnimation();
        Console.WriteLine("Prepare to begin...");
        ShowAnimation();

        for (int i = 0; i < Duration / 4; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowAnimation();
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("Breathe out...");
            ShowAnimation();
            System.Threading.Thread.Sleep(2000);
        }

        EndActivity();
    }
}

public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    { }

    public override void StartActivity()
    {
        Console.WriteLine($"{ActivityName}: {Description}");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        Duration = duration;

        ShowAnimation();

        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need."
        };

        Random random = new Random();
        string selectedPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(selectedPrompt);
        ShowAnimation();

        string[] questions = {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn about yourself through this experience?"
        };

        foreach (var question in questions)
        {
            Console.WriteLine(question);
            ShowAnimation();
            System.Threading.Thread.Sleep(4000);
        }

        EndActivity();
    }
}

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    public override void StartActivity()
    {
        Console.WriteLine($"{ActivityName}: {Description}");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        Duration = duration;

        ShowAnimation();

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?"
        };

        Random random = new Random();
        string selectedPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(selectedPrompt);
        ShowAnimation();

        Console.WriteLine("You have 5 seconds to begin...");
        ShowAnimation();
        System.Threading.Thread.Sleep(5000);

        List<string> items = new List<string>();
        int timeLimit = Duration * 1000;
        int startTime = Environment.TickCount;

        while (Environment.TickCount - startTime < timeLimit)
        {
            Console.WriteLine("Please list an item (or type 'done' to finish):");
            string item = Console.ReadLine();
            if (item.ToLower() == "done")
                break;
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
            }

            if (activity != null)
            {
                activity.StartActivity();
            }
        }
    }
}
