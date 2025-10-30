using System;
using Task_03.Classes;
internal class Program
{
    static void Main(string[] args)
    {
        List<string> colors = Console.ReadLine().Split(" ").ToList();
        int n = int.Parse(Console.ReadLine());
        TrafficLight trafficLight = new TrafficLight(colors);
        trafficLight.MoveLights(n);
    }
}

