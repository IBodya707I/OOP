using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01.Interfaces
{
    internal interface Auto
    {
        public string Type
        {
            get;
        }
        public double Fuel
        {
            get;
        }
        public double FuelConsumption
        {
            get;
        }
        public void Drive(double distance);
        public void Refuel(double amount);
    }
}
