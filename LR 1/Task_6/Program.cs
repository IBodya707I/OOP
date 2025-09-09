using System;
    internal class Program
    {
        static void Main()
        {
            float a, b, h;
            float area;
            Console.WriteLine("Enter side: ");
            a = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter side: ");
            b = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            h = float.Parse(Console.ReadLine());
            area = (a + b) * h / 2f;
            Console.WriteLine(area);
        }
    }
