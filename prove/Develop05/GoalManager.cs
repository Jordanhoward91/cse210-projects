using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuest
{
	public class GoalManager
	{
		private List<Goal> goals;
		private int userScore;

		public GoalManager()
		{
			goals = new List<Goal>();
			userScore = 0;
		}

		public void CreateGoal(Goal goal)
		{
			goals.Add(goal);
		}

		public void RecordEvent(int goalIndex)
		{
			if (goalIndex >= 0 && goalIndex < goals.Count)
			{
				goals[goalIndex].RecordEvent();
				userScore += goals[goalIndex].Points;
				if (goals[goalIndex] is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
				{
					userScore += checklistGoal.BonusPoints;
				}
			}
		}

		public void DisplayGoals()
		{
			for (int i = 0; i < goals.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
			}
			Console.WriteLine($"User Score: {userScore}");
		}

		public void SaveGoals(string filePath)
		{
			var saveData = new SaveData { Goals = goals, UserScore = userScore };
			var options = new JsonSerializerOptions { WriteIndented = true };
			File.WriteAllText(filePath, JsonSerializer.Serialize(saveData, options));
		}

		public void LoadGoals(string filePath)
		{
			if (File.Exists(filePath))
			{
				var saveData = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(filePath));
				if (saveData != null)
				{
					goals = saveData.Goals;
					userScore = saveData.UserScore;
				}
			}
		}
	}
}
