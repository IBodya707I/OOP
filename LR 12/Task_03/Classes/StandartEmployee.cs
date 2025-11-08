using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;

namespace Task_03.Classes
{
    internal class StandartEmployee: IEmployee
    {
        private string name;
        private int workHoursPerWeek = 40;
        public string Name
        {
            get { return name; } 
            private set { name = value; }
        }
        public int WorkHoursPerWeek
        {
            get { return workHoursPerWeek; }
        }
        public StandartEmployee(string name)
        {
            Name = name;
        }  

    }
}
