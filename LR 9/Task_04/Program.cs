using System;
using Classes;
internal class Program
{
    static void Swap<T>(List<T> list, int x1, int x2)
    {
        T t = list[x1];
        list[x1] = list[x2];
        list[x2] = t;
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
        int[] x = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Swap(boxes, x[0], x[1]);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(boxes[i]);
        }
    }
}

