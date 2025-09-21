using System;
internal class Program
    {
        static void Main()
        {
            Console.Write("Enter array: ");
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.Write("Enter difference: ");
            int difference = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for(int j = i + 1; j < array.Length; j++)
                {
                    if(Math.Abs(array[i] - array[j]) == difference)
                    {
                        Console.WriteLine("{" + array[i]+", " + array[j]+"}");
                        count++;
                    }
                }
            }
            Console.WriteLine("Count: " + count);
        }
    }

