using System;
    internal class Program
    {
        static void Main()
        {
            int n, LastDigit;
            Console.WriteLine("Enter number: ");
            n = int.Parse(Console.ReadLine());
            LastDigit = n % 10;
            Console.WriteLine($"Last Digit: {LastDigit}");
        }
    }
