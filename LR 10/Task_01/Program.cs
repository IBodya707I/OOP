using System;
using Task_01.Classes;
internal class Program
{
    static void Main()
    {
        int count = 0;
        bool Created = false;   
        ListyIterator<string> listyIterator = new ListyIterator<string>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(" ");
            if (input[0].ToLower() == "end")
                break;
            if (count == 100)
            {
                Console.WriteLine("Error: Too many commands."); break;
            }
            if (input[0].ToLower() == "create")
            {
                if (Created)
                {
                    Console.WriteLine("Error: ListyIterator already created."); break;
                }
                string[] items = input.Skip(1).ToArray();
                listyIterator.AddList(items);
                Created = true;
            }
            else if (input[0].ToLower() == "move" && Created)
            {
                Console.WriteLine(listyIterator.Move());
            }
            else if (input[0].ToLower() == "hasnext" && Created)
            {
                Console.WriteLine(listyIterator.HasNext());
            }
            else if (input[0].ToLower() == "print" && Created)
            {
                try
                {
                    listyIterator.Print();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            count++;
        }
    }
}

