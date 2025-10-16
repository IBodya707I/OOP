using System;
using Task_01.Interfaces;
using Task_01.Classes;
internal class Program
{
    static void Main()
    {
        List<Auto> autos = new List<Auto>();
        string[] text = Console.ReadLine().Split(" ");
        Car car = new Car(text[0], double.Parse(text[1]), double.Parse(text[2]));
        autos.Add(car);
        text = Console.ReadLine().Split(" ");
        Truck truck = new Truck(text[0], double.Parse(text[1]), double.Parse(text[2]));
        autos.Add(truck);
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            text = Console.ReadLine().Split(" ");
            if (text[0].ToLower() == "end")
                break;
            string command = text[0];
            foreach (Auto auto in autos)
            {
                if (auto.Type.ToLower() == text[1].ToLower())
                {
                    if (command.ToLower() == "drive")
                    {
                        auto.Drive(double.Parse(text[2]));
                    }
                    else if (command.ToLower() == "refuel")
                    {
                        auto.Refuel(double.Parse(text[2]));
                    }
                }
            }
        }
        foreach (Auto auto in autos)
        {
            Console.WriteLine(auto.Type + ": " + auto.Fuel.ToString("F2"));

        }
    }
}
