using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Manager", "Apple", 2022, 2023);
        Resume resume = new Resume();

        resume._name = "James";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}