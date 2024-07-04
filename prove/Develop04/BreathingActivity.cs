public class BreathingActivity : MindfulnessActivity
{
	public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
	{
	}

	public override void PerformActivity(int duration)
	{
		DateTime endTime = DateTime.Now.AddSeconds(duration);
		while (DateTime.Now < endTime)
		{
			Console.WriteLine("Breathe in...");
			ShowSpinner(4);
			Console.WriteLine("Breathe out...");
			ShowSpinner(4);
		}
	}
}
