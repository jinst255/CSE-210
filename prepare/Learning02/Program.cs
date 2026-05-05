using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        
        Job job1 = new Job();
        job1._startYear = 2020;
        job1._endYear = 2022;
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";

        Job job2 = new Job();
        job2._startYear = 2022;  
        job2._endYear = 2025;  
        job2._company = "Apple";  
        job2._jobTitle = "Software Developer"; 

        // add jobs to a Resume instance
        Resume myResume = new Resume();
        myResume._name = "Justin";
        myResume._jobs = new List<Job>();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}

