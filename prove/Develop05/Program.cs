using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            // Sample goals for demonstration
            goalManager.CreateGoal(new SimpleGoal("Run a marathon", 1000));
            goalManager.CreateGoal(new EternalGoal("Read scriptures", 100));
            goalManager.CreateGoal(new ChecklistGoal("Attend the temple", 50, 10, 500));

            string userInput;
            do
            {
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Display Goals");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        goalManager.CreateGoal(GoalFactory.CreateGoal());
                        break;
                    case "2":
                        goalManager.DisplayGoals();
                        Console.Write("Enter goal number to record: ");
                        int goalNumber;
                        if (int.TryParse(Console.ReadLine(), out goalNumber))
                        {
                            goalManager.RecordEvent(goalNumber - 1);
                        }
                        break;
                    case "3":
                        goalManager.DisplayGoals();
                        break;
                    case "4":
                        Console.Write("Enter file path to save: ");
                        string savePath = Console.ReadLine();
                        goalManager.SaveGoals(savePath);
                        break;
                    case "5":
                        Console.Write("Enter file path to load: ");
                        string loadPath = Console.ReadLine();
                        goalManager.LoadGoals(loadPath);
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            } while (userInput != "6");
        }
    }
}
