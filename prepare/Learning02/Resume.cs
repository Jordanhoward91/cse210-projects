using System;
using System.Collections.Generic;

namespace YourNamespace
{
	public class Resume
	{
		// Member variables
		public string _name;
		public List<Job> _jobs;

		// Constructor to initialize the list
		public Resume()
		{
			_jobs = new List<Job>();
		}

		// Method to display resume details
		public void Display()
		{
			Console.WriteLine($"Name: {_name}");
			Console.WriteLine("Jobs:");
			foreach (var job in _jobs)
			{
				job.DisplayJobDetails();
			}
		}
	}
}
