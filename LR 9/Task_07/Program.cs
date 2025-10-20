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
        List<Box<double>> boxes = new List<Box<double>>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            double number = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>(number);
            boxes.Add(box);
        }
        double x = double.Parse(Console.ReadLine());
        Box<double> c = new Box<double>(x);
        int count = Count(boxes, c);
        Console.WriteLine(count);
    }
}

