// Going above and beyond is Keeping a log of how many times activities were performed..

using System;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessActivity[] activities = {
            new BreathingActivity(),
            new ReflectionActivity(),
            new ListingActivity()
        };

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Show Activity Counts");
            Console.WriteLine("5. Quit");

            Console.Write("Enter the number of the activity: ");
            string choice = Console.ReadLine();

            if (choice == "5")
                break;

            if (choice == "4")
            {
                ShowActivityCounts(activities);
                continue;
            }

            if (int.TryParse(choice, out int activityNum) && activityNum >= 1 && activityNum <= activities.Length)
            {
                Console.Write("Enter the duration of the activity in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    activities[activityNum - 1].StartActivity(duration);
                    activities[activityNum - 1].PerformActivity(duration);
                    activities[activityNum - 1].EndActivity(duration);
                }
                else
                {
                    Console.WriteLine("Invalid duration. Please enter a valid number of seconds.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }
        }
    }

    static void ShowActivityCounts(MindfulnessActivity[] activities)
    {
        foreach (var activity in activities)
        {
            Console.WriteLine($"{activity.GetType().Name}: {activity.GetCounter()} times");
        }
    }
}
