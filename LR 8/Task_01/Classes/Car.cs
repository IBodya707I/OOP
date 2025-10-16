using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_01.Interfaces;
namespace Task_01.Classes
{
    internal class Car: Auto
    {
        private string type;
        private double fuel;
        private double fuelConsumption;
        public string Type
        {
            get { return type; }
            private set { type = value; }
        }
        public double Fuel
        {
            get { return fuel; }
            private set { fuel = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + 0.9; }
        }
        public Car(string type, double fuel, double fuelConsumption)
        {
            Type = type;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }
        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > Fuel)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                Fuel -= neededFuel;
                Console.WriteLine("Car traveled " + distance + "km");
            }
        }
        public void Refuel(double amount)
        {
            Fuel += amount;
        }
    }
}
