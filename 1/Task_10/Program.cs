using System;
    internal class Program
    {
        static void Main()
        {
            int n;
            bool result;
            Console.WriteLine("Enter n: ");
            n = int.Parse(Console.ReadLine());
            if (n % 9 == 0 || n % 11 == 0 || n % 13 == 0)
            {
                result = true;
                Console.WriteLine(result);
            }
            else
            {
                result = false;
                Console.WriteLine(result);
            }
        }
    }
