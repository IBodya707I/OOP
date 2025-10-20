using System;
using Task_09.Classes;
    internal class Program
    {
        static void Main(string[] args)
        {
        CustomList<string> list = new CustomList<string>();
        while (true)
        {
            string[] text = Console.ReadLine().Split(" ");
            if (text[0].ToLower() == "end")
                break;
            else if (text[0].ToLower() == "add")
                list.Add(text[1]);
            else if (text[0].ToLower() == "remove")
            {
                int index = int.Parse(text[1]);
                list.Remove(index);
            }
            else if (text[0].ToLower() == "contains")
                Console.WriteLine(list.Contains(text[1]));
            else if (text[0].ToLower() == "swap")
                list.Swap(int.Parse(text[1]), int.Parse(text[2]));
            else if (text[0].ToLower() == "greater")
                Console.WriteLine(list.CountGreaterThan(text[1]));
            else if (text[0].ToLower() == "max")
                Console.WriteLine(list.Max());
            else if (text[0].ToLower() == "min")
                Console.WriteLine(list.Min());
            else if (text[0].ToLower() == "print")
                list.Print();
            else if(text[0].ToLower() == "sort")
                Sorting.Sort(list);

        }
    }
    }

