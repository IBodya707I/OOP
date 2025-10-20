using System;
using Classes;
    internal class Program
    {
        static int Count<T>(List<Box<T>> list, Box<T> item) where T : IComparable<T> 
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
            if (list[i].Value.CompareTo(item.Value) > 0)
                    count++;
            }
            return count;
        }
        static void Main()
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                Box<string> box = new Box<string>(text);
                boxes.Add(box);
            }
            string x = Console.ReadLine();
            Box<string> c = new Box<string>(x);
        int count = Count(boxes, c);
        Console.WriteLine(count);   
    }
    }

