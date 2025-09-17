using System;
internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter array: ");
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine("Enter k: ");
            int k = int.Parse(Console.ReadLine());
            int n = array.Length;
            int[] sum = new int[n];
            for (int i = 0; i < k; i++)
            {
                int t = array[n - 1];
                for(int j = n - 1; j > 0; j--)
                {
                    array[j] = array[j - 1];
                }
                array[0] = t;
                Console.Write("rotated" + (i + 1) + ": ");
                for (int j = 0; j < n; j++)
                {
                    sum[j] += array[j];
                    Console.Write(array[j] + " ");
                }
                Console.WriteLine();

            }
            for(int i = 0; i < n; i++)
            {
                Console.Write(sum[i] + " ");
            }

        }
    }

