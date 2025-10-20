using System;
using Classes;
    internal class Program
    {
        static void Main()
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                Box<string> box = new Box<string>(text);
                boxes.Add(box);
            }
            for(int i = 0;i < n; i++)
            {
                Console.WriteLine(boxes[i]);
            }
        }
    }

