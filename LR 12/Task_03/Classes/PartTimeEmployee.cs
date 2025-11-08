using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class PartTimeEmployee: IEmployee
    {
        private string name;
        private int workHoursPerWeek = 20;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int WorkHoursPerWeek
        {
            get { return workHoursPerWeek; }
        }
        public PartTimeEmployee(string name)
        {
            Name = name;
        }
    }
}
