using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Interfaces;
namespace Task_02.Classes
{
    internal class Truck: Auto
    {
        private string type;
        private double fuel;
        private double fuelConsumption;
        private double tank;
        public double Tank
        {
            get { return tank; }
            private set { tank = value; }
        }
        public string Type
        {
            get { return type; }
            private set { type = value; }
        }
        public double Fuel
        {
            get { return fuel; }
            private set 
            { 
                    fuel = value; 
            }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + 1.6; }
        }
        public Truck(string type, double fuel, double fuelConsumption, double tank)
        {
            Type = type;
            Tank = tank;
            Fuel = fuel;
            FuelConsumption = fuelConsumption;
        }
        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel > Fuel)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Fuel -= neededFuel;
                Console.WriteLine("Truck traveled " + distance + "km");
            }
        }
        public void Refuel(double amount)
        {
            if (amount > Tank)
            {
                Console.WriteLine("Cannot fit " + amount + " fuel in tank");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
                Fuel += amount * 0.95;
        }
    }
}
