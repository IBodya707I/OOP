using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class Private: Soldier, IPrivate
    {
        private double salary;
        public double Salary
        {
            get { return salary; }
            private set { salary = value; }
        }
        public Private(string id, string firstName, string lastName, double salary): base(id, firstName, lastName)
        {
            Salary = salary;
        }
        public override string ToString()
        {
            return (base.ToString() + " Salary: " + Salary.ToString("F2"));
        }
    }
}
