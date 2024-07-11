using System;

namespace EternalQuest
{
	class GoalFactory
	{
		public static Goal CreateGoal()
		{
			Console.WriteLine("Select the type of goal to create:");
			Console.WriteLine("1. Simple Goal");
			Console.WriteLine("2. Eternal Goal");
			Console.WriteLine("3. Checklist Goal");
			string choice = Console.ReadLine();

			Console.Write("Enter goal description: ");
			string description = Console.ReadLine();

			Console.Write("Enter points for completing the goal: ");
			int points = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case "1":
					return new SimpleGoal(description, points);
				case "2":
					return new EternalGoal(description, points);
				case "3":
					Console.Write("Enter the number of times to complete the goal: ");
					int requiredCount = int.Parse(Console.ReadLine());
					Console.Write("Enter the bonus points for completing the goal: ");
					int bonusPoints = int.Parse(Console.ReadLine());
					return new ChecklistGoal(description, points, requiredCount, bonusPoints);
				default:
					Console.WriteLine("Invalid choice. Creating a simple goal by default.");
					return new SimpleGoal(description, points);
			}
		}
	}
}
