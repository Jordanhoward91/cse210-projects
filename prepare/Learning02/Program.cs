using System;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new job instance named job1
            Job job1 = new Job
            {
                _jobTitle = "Software Engineer",
                _company = "Microsoft",
                _location = "Redmond, WA",
                _startDate = new DateTime(2019, 1, 1),
                _endDate = new DateTime(2022, 1, 1),
                _jobDescription = "Developing software solutions."
            };

            // Create a second job instance named job2
            Job job2 = new Job
            {
                _jobTitle = "Manager",
                _company = "Apple",
                _location = "Cupertino, CA",
                _startDate = new DateTime(2022, 1, 1),
                _endDate = new DateTime(2023, 1, 1),
                _jobDescription = "Managing product lifecycle."
            };

            // Create a new instance of the Resume class
            Resume myResume = new Resume
            {
                _name = "Allison Rose"
            };

            // Add the jobs to the list of jobs in the resume object
            myResume._jobs.Add(job1);
            myResume._jobs.Add(job2);

            // Verify that you can access and display the first job title
            // Console.WriteLine(myResume._jobs[0]._jobTitle);

            // Call the Display method to display the resume details
            myResume.Display();
        }
    }
}
