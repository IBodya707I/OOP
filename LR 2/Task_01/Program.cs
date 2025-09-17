using System;
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter line: ");
            string[] a = Console.ReadLine().Split(' ');
            Console.WriteLine("Enter line: ");
            string[] b = Console.ReadLine().Split(' ');
            int right = 0, left = 0;
            int minLength, i;
            if (a.Length > b.Length)
                minLength = b.Length;
            else
                minLength = a.Length;
            for (i = 0; i < minLength; i++)
            {
                if (a[i] == b[i])
                    left++;
                else
                    break;
            }
            for (i = 1; i <= minLength; i++)
            {
                if (a[a.Length - i] == b[b.Length - i])
                    right++;
                else
                    break;
            }
            if(right == 0 && left == 0)
                Console.WriteLine("No common words");
            else if (right >= left)
            {
                Console.WriteLine($"Count from right: {right}");
                for (i = 0; i < right; i++)
                    Console.Write(a[a.Length - right + i] + " ");
            }
            else if (left >= right)
            {
                Console.WriteLine($"Count from left: {left}");
                for (i = 0; i < left; i++)
                    Console.Write(a[i] + " ");
            }

        }
    }

