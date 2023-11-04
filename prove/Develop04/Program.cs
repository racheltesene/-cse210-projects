using System;
using System.Threading;

class MindfulnessActivity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Starting {Name} Activity...");
        Console.WriteLine(Description);
        Thread.Sleep(2000); // Pause for 2 seconds

        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    public virtual void End()
    {
        Console.WriteLine("You have completed the activity.");
        Console.WriteLine($"Duration: {Duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        base.Start();
    }

    public override void End()
    {
        base.End();
    }

    public void PerformBreathingActivity()
    {
        Start();
        Console.WriteLine("Breathe in...");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine("Breathe out...");
        Thread.Sleep(2000); // Pause for 2 seconds

        for (int i = 0; i < Duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // Pause for 2 seconds
        }

        End();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        base.Start();
    }

    public override void End()
    {
        base.End();
    }

    public void PerformReflectionActivity()
    {
        Start();
        Console.WriteLine("Think of a time when you stood up for someone else.");
        Thread.Sleep(2000); // Pause for 2 seconds

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            // Add more questions here...
        };

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Pause for 2 seconds
        }

        for (int i = questions.Length; i < Duration; i += (questions.Length + 1))
        {
            Console.WriteLine("Think of a time when you stood up for someone else.");
            Thread.Sleep(2000); // Pause for 2 seconds

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000); // Pause for 2 seconds
            }
        }

        End();
    }
}

class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Start()
    {
        base.Start();
    }

    public override void End()
    {
        base.End();
    }

    public void PerformListingActivity()
    {
        Start();
        Console.WriteLine("Who are people that you appreciate?");
        Thread.Sleep(2000); // Pause for 2 seconds

        // Add more prompts here...

        int itemCount = 0;
        for (int i = 0; i < Duration; i += 2)
        {
            itemCount++;
            Thread.Sleep(2000); // Pause for 2 seconds
        }

        Console.WriteLine($"You listed {itemCount} items.");
        End();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Activities Program");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid activity.");
                    break;
            }

            if (activity != null)
            {
                Console.Write("Enter duration (in seconds): ");
                activity.Duration = int.Parse(Console.ReadLine());

                if (activity is BreathingActivity)
                {
                    ((BreathingActivity)activity).PerformBreathingActivity();
                }
                else if (activity is ReflectionActivity)
                {
                    ((ReflectionActivity)activity).PerformReflectionActivity();
                }
                else if (activity is ListingActivity)
                {
                    ((ListingActivity)activity).PerformListingActivity();
                }
            }
        }
    }
}

