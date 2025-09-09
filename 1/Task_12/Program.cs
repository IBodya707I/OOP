using System;
    internal class Program
    {
        static void Main()
        {
            double a, b, c;
            Console.WriteLine("Enter number: ");
            a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number: ");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter number: ");
            c = double.Parse(Console.ReadLine());
            int count = 0;
            if (a < 0)
                count++;
            if (b < 0) 
                count++;
            if (c < 0)
                count++;
            if (count % 2 != 0)
                Console.WriteLine("Negative");
            else
                Console.WriteLine("Positive");
        }
    }
