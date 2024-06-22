using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
	private List<Entry> entries;
	private List<string> prompts;

	public Journal()
	{
		entries = new List<Entry>();
		prompts = new List<string>
		{
			"Who was the most interesting person I interacted with today?",
			"What was the best part of my day?",
			"How did I see the hand of the Lord in my life today?",
			"What was the strongest emotion I felt today?",
			"If I had one thing I could do over today, what would it be?"
		};
	}

	public void WriteNewEntry()
	{
		Random random = new Random();
		string prompt = prompts[random.Next(prompts.Count)];
		Console.WriteLine(prompt);
		string response = Console.ReadLine();
		string date = DateTime.Now.ToString("yyyy-MM-dd");

		Entry entry = new Entry(prompt, response, date);
		entries.Add(entry);
	}

	public void DisplayJournal()
	{
		foreach (Entry entry in entries)
		{
			Console.WriteLine(entry.ToString());
		}
	}

	public void SaveJournal(string filename)
	{
		using (StreamWriter writer = new StreamWriter(filename))
		{
			writer.WriteLine("Date,Prompt,Response"); // CSV header
			foreach (Entry entry in entries)
			{
				writer.WriteLine(entry.ToCsv());
			}
		}
	}

	public void LoadJournal(string filename)
	{
		entries.Clear();
		using (StreamReader reader = new StreamReader(filename))
		{
			string line;
			reader.ReadLine(); // Skip the header
			while ((line = reader.ReadLine()) != null)
			{
				Entry entry = Entry.FromCsv(line);
				entries.Add(entry);
			}
		}
	}
}
