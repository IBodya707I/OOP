using System;
    internal class Program
    {
        static void Main()
        {
            int a, b, c;
            float average;
            Console.WriteLine("Enter number: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number: ");
            c = int.Parse(Console.ReadLine());
            average = (a + b + c) / 3f;
            Console.WriteLine(average);
        }
    }

