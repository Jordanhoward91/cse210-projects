using System;

namespace EternalQuest
{
	public class ChecklistGoal : Goal
	{
		private int _requiredCount;
		private int _completedCount;
		private int _bonusPoints;

		public ChecklistGoal(string description, int points, int requiredCount, int bonusPoints)
			: base(description, points)
		{
			_requiredCount = requiredCount;
			_bonusPoints = bonusPoints;
			_completedCount = 0;
		}

		public override void RecordEvent()
		{
			_completedCount++;
		}

		public override string GetDetailsString()
		{
			return $"[ {(_completedCount >= _requiredCount ? "X" : " ")} ] {description} - {points} points " +
				   $"(Completed {_completedCount}/{_requiredCount} times)";
		}

		public override bool IsComplete()
		{
			return _completedCount >= _requiredCount;
		}

		public int BonusPoints
		{
			get { return _bonusPoints; }
		}
	}
}
