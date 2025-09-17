using System;
internal class Program
    {
        static void Main()
        {
            Console.Write("Enter first array: ");
            char[] first = Console.ReadLine().Replace(" ", "").ToCharArray();
            Console.Write("Enter second array: ");
            char[] second = Console.ReadLine().Replace(" ", "").ToCharArray();
            int minLength;
            if (first.Length < second.Length)
            {
                minLength = first.Length;
            }
            else
            {
                minLength = second.Length;
            }
            bool t = true;
            for(int i = 0; i < minLength; i++)
            {
                if(first[i] < second[i])
                {
                    for(int j = 0; j < first.Length; j++)
                    {
                        Console.Write(first[j]);
                    }
                    Console.WriteLine();
                    for (int j = 0; j < second.Length; j++)
                    {
                        Console.Write(second[j]);
                    }
                    t = false;
                    break;
                }
                else if(first[i] > second[i])
                {
                    for(int j = 0; j < second.Length; j++)
                    {
                        Console.Write(second[j]);
                    }
                    Console.WriteLine();
                    for(int j = 0; j < first.Length; j++)
                    {
                        Console.Write(first[j]);
                    }
                    t = false;
                    break;
                }
            }
            if(t == true)
            {
                if (first.Length < second.Length)
                {
                    for (int j = 0; j < first.Length; j++)
                    {
                        Console.Write(first[j]);
                    }
                    Console.WriteLine();
                    for (int j = 0; j < second.Length; j++)
                    {
                        Console.Write(second[j]);
                    }
                }
                else
                {
                    for (int j = 0; j < second.Length; j++)
                    {
                        Console.Write(second[j]);
                    }
                    Console.WriteLine();
                    for (int j = 0; j < first.Length; j++)
                    {
                        Console.Write(first[j]);
                    }
                }
            }
        }
    }
