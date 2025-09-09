using System;
    internal class Program
    {
        static void Main()
        {
            int n, number, ndigit;
            Console.WriteLine("Enter number: ");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter n: ");
            n = int.Parse(Console.ReadLine());
            ndigit = (int)(number/Math.Pow(10, n - 1)) % 10;
            if(ndigit == 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine(ndigit);
            
            }
        }
    }
