using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // job1.Display();

        // string reslt = job1.Display();
        // Console.WriteLine(reslt);

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // job2.Display();

        // string reslt1 = job2.Display();
        // Console.WriteLine(reslt1);
        Resume resume1 = new Resume();
        resume1._personeName = "Allison Rose";

        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();



        // Console.WriteLine(resume1._jobs[0]._jobTitle);


    }




}