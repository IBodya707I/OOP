using System;
internal class Program
    {
        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            bool[]primes = new bool[n + 1];
            for(int i = 0; i <= n; i++)
            {
                if(i < 2)
                    primes[i] = false;
                else
                    primes[i] = true;
            }
            for(int i = 2; i * i <= n; i++)
            {
                if(primes[i] == true)
                {
                    for(int j = i * i; j <= n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            for(int i = 2; i <= n; i++)
            {
                if(primes[i] == true)
                    Console.Write(i + " ");
            }
        }
    }

