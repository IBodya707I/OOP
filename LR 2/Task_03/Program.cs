using System;
internal class Program
    {
        static void Main()
        {
            int n=0;
            int[] array = new int[0];
            Console.WriteLine("Enter array with length 4*n: ");
            while (n == 0 || n % 4 != 0)
            {
                array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                n = array.Length; 
                if (n % 4 != 0)
                {
                    Console.WriteLine("Try again: ");
                
                }
            }
            int[] first = new int[n / 2];
            int [] second = new int[n / 2];
            int k = n / 4;
            for ( int i = 0; i < k; i++)
            {
                first [i] = array[k - 1 - i];
            }
            for (int i = 0; i < k; i++)
            {
                first[k + i] = array[n - 1 - i];
            }
            for (int i = 0; i < n/2; i++)
            {
                second[i] = array[k + i];
            }
            int[] sum = new int[n/2];
            for (int i = 0; i < n/2; i++)
            {
                sum[i] = first[i] + second[i];
                Console.Write(sum[i] + " ");
            }
        }
    }

