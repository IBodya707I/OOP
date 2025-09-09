using System;
internal class Program
    {
        static void Main()
        {
            int n;
            bool result;
            Console.WriteLine("Enter n: ");
            n = int.Parse(Console.ReadLine());
            if(n > 20 && n % 2 !=0)
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
