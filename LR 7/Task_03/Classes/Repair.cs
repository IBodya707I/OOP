using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    internal class Repair
    {
        private string partName;
        private int hoursWorked;
        public string PartName
        {
            get { return partName; }
            private set { partName = value; }
        }
        public int HoursWorked
        {
            get { return hoursWorked; }
            private set { hoursWorked = value; }
        }
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }
        public override string ToString()
        {
            return ("Part Name: " + PartName + " Hours Worked: " + HoursWorked);
        }
    }
}
