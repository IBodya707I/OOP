using System;
using Task_01.Classes;
internal class Program
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] links = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Smartphone smartphone = new Smartphone();
        foreach (string number in numbers)
        {
            try
            {
                smartphone.Call(number);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
        foreach (string link in links)
        {
            try
            {
                smartphone.Browse(link);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

