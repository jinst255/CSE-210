using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Clear();

        // Create an instance of 
        Filer writer = new Filer();
        writer.WriteJoke();

        Console.WriteLine();

        writer.ReadJoke();
    }
}

class Filer
{
    public void WriteJoke()
    {
        string fileName = "testFile.txt";

        Console.WriteLine("Enter some text to write to the file:");
        string text = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine("Here is a joke:");
            outputFile.WriteLine(text);
        }

        Console.WriteLine($"File created at: {Path.GetFullPath(fileName)}");
    }

    public void ReadJoke()
    {
        string fileName = "testFile.txt";

        if (File.Exists(fileName))
        {
            using (StreamReader inputFile = new StreamReader(fileName))
            {
                string content = inputFile.ReadToEnd();
                Console.WriteLine("File content:");
                Console.WriteLine(content);
            }
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}


/*

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


class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();
    
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}

public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

*/