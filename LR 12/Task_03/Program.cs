using System;
using Task_03.Classes;
using Task_03.Interfaces;
internal class Program
{
    static void Main(string[] args)
    {
        List<IEmployee> employees = new List<IEmployee>();
        JobList jobList = new JobList();
        while (true)
        {
            string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (text[0].ToLower() == "end")
            {
                break;
            }
            switch (text[0].ToLower())
            {
                case "standartemployee":
                    {
                        IEmployee employee = new StandartEmployee(text[1]);
                        employees.Add(employee);
                        break;
                    }
                case "parttimeemployee":
                    {
                        IEmployee employee = new PartTimeEmployee(text[1]);
                        employees.Add(employee);
                        break;
                    }
                case "job":
                    {
                        string jobName = text[1];
                        int hoursRequired = int.Parse(text[2]);
                        string employeeName = text[3];
                        IEmployee employee = employees.Find(e => e.Name == employeeName);
                        if (employee != null)
                        {
                            Job job = new Job(jobName, hoursRequired, employee);
                            jobList.AddJob(job);
                        }
                        break;
                    }
                case "pass":
                    {
                        if (text[1].ToLower() == "week")
                            jobList.UpdateJobs();
                        break;
                    }
                case "status":
                    {
                        jobList.PrintJobs();
                        break;
                    }
            }
        }
    }
}

