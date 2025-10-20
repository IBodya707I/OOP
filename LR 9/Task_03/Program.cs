using System;
using Classes;
    internal class Program
    {
        static void Main()
        {
        List<Box<int>> boxes = new List<Box<int>>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(number);
            boxes.Add(box);
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(boxes[i]);
        }
    }
    }

