using System;
    internal class Program
    {
        static void Main()
        {
            int a, b, c;
            Console.WriteLine("Enter number: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number: ");
            c = int.Parse(Console.ReadLine());
            int max = a;
            if(b > max)
            {
                max = b;
            }
            if(c > max)
            {
                max = c;
            }
            Console.WriteLine( max);
        }
    }
