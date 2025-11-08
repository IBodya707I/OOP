using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    internal class JobList
    {
        private List<Job> jobs;
        public List<Job> Jobs
        {
            get { return jobs; }
            private set { jobs = value; }
        }
        public JobList()
        {
            Jobs = new List<Job>();
        }
        public void AddJob(Job job)
        {
            Jobs.Add(job);
            job.JobDone += RemoveJob;
        }
        public void RemoveJob(Job job)
        {
            Jobs.Remove(job);
        }
        public void PrintJobs()
        {
            foreach (var job in Jobs)
            {
                Console.WriteLine($"Job: {job.Name} Hours Remaining: {job.HoursRemaining}");
            }
        }
        public void UpdateJobs()
        {
            foreach (var job in Jobs)
            {
                job.Update();
            }
        }
    }
}
