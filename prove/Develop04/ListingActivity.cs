using System;

public class ListingActivity : MindfulnessActivity
{
	private string[] prompts = {
		"Who are people that you appreciate?",
		"What are personal strengths of yours?",
		"Who are people that you have helped this week?",
		"When have you felt the Holy Ghost this month?",
		"Who are some of your personal heroes?"
	};

	public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
	{
	}

	public override void PerformActivity(int duration)
	{
		Random rand = new Random();
		string prompt = prompts[rand.Next(prompts.Length)];
		Console.WriteLine(prompt);
		Console.WriteLine("You have a few seconds to prepare your thoughts...");
		ShowSpinner(5);

		Console.WriteLine("Start listing items now:");
		DateTime endTime = DateTime.Now.AddSeconds(duration);
		int count = 0;
		while (DateTime.Now < endTime)
		{
			string item = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(item))
				count++;
		}
		Console.WriteLine($"You listed {count} items.");
	}
}
