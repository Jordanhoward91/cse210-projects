using System;

namespace EternalQuest
{
	public class EternalGoal : Goal
	{
		public EternalGoal(string description, int points) : base(description, points) { }

		public override void RecordEvent()
		{
			// Eternal goals are never complete, just add points
		}

		public override string GetDetailsString()
		{
			return $"{description} - {points} points (eternal)";
		}

		public override bool IsComplete()
		{
			return false; // Eternal goals are never complete
		}
	}
}
