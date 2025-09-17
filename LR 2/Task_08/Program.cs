using System;
internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter array: ");
            ushort[] array = Array.ConvertAll(Console.ReadLine().Split(' '), ushort.Parse);
            int[] x = new int[65536];
            int number = array[0];
            int maxCount = 1;
            for (int i = 0; i < array.Length; i++)
            {
                x[array[i]]++;
                if(x[array[i]] > maxCount)
                {
                    maxCount = x[array[i]];
                    number = array[i];
                }
            }
            Console.WriteLine("Number: " + number + ": " + maxCount + "times");
        }
    }

