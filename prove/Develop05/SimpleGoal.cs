using System;

namespace EternalQuest
{
	public class SimpleGoal : Goal
	{
		private bool _isComplete;

		public SimpleGoal(string description, int points) : base(description, points)
		{
			_isComplete = false;
		}

		public override void RecordEvent()
		{
			_isComplete = true;
		}

		public override string GetDetailsString()
		{
			return $"[ {(IsComplete() ? "X" : " ")} ] {description} - {points} points";
		}

		public override bool IsComplete()
		{
			return _isComplete;
		}
	}
}
