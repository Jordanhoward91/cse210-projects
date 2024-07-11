using System;

namespace EternalQuest
{
	public abstract class Goal
	{
		protected string description;
		protected int points;

		public Goal(string description, int points)
		{
			this.description = description;
			this.points = points;
		}

		public int Points
		{
			get { return points; }
		}

		public abstract void RecordEvent();
		public abstract string GetDetailsString();
		public abstract bool IsComplete();
	}
}
