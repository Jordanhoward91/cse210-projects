using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int counter;  // Counter to track the number of times the activity has been performed

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
        this.counter = 0;
    }

    public void StartActivity(int duration)
    {
        counter++;  // Increment the counter each time the activity starts
        Console.WriteLine($"Starting {name} activity.");
        Console.WriteLine(description);
        Console.WriteLine($"This activity will last for {duration} seconds.");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(5);
    }

    public void EndActivity(int duration)
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        ShowSpinner(5);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }

    public abstract void PerformActivity(int duration);

    public int GetCounter()
    {
        return counter;  // Return the number of times the activity has been performed
    }
}
