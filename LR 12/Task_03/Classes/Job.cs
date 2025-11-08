using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class Job
    {
        private string name;
        private int hoursRemaining;
        private IEmployee employee;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int HoursRemaining
        {
            get { return hoursRemaining; }
            private set { hoursRemaining = value; }
        }
        public IEmployee Employee
        {
            get { return employee; }
            private set { employee = value; }
        }
        public Job(string name, int hoursRequired, IEmployee employee)
        {
            Name = name;
            HoursRemaining = hoursRequired;
            Employee = employee;
        }
        public event Action<Job> JobDone;
        public void Update()
        {
            HoursRemaining -= Employee.WorkHoursPerWeek;
            if (HoursRemaining <= 0)
            {
                Console.WriteLine($"Job {Name} done!");
                JobDone?.Invoke(this);
            }
        }
    }
}
