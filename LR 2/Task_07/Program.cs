using System;
internal class Program
{
    static void Main()
    {
        Console.Write("Enter array: ");
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int currentLength = 1;
        int Pos = 0;
        int maxLength = 1;
        int number;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > array[i - 1])
            {
                currentLength++;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    Pos = i - maxLength;
                }
            }
            else
                currentLength = 1;
        }
        for (int i = Pos + 1; i <= Pos + maxLength; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
