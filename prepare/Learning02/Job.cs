using System;

namespace YourNamespace
{
	public class Job
	{
		// Member variables
		public string _jobTitle;
		public string _company;
		public string _location;
		public DateTime _startDate;
		public DateTime _endDate;
		public string _jobDescription;

		// Method to display job details
		public void DisplayJobDetails()
		{
			Console.WriteLine($"{_jobTitle} ({_company}) {_startDate.Year}-{_endDate.Year}");
		}
	}
}
