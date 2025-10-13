using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_02.Classes;
using Task_02.Interfaces;

namespace Task_02
{
    internal class Part_03
    {
        public static void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] text = Console.ReadLine().Split();
                    foreach (IBuyer buyer in buyers)
                    {
                        if (buyer.Name == text[0])
                        {
                            throw new ArgumentException("Name already exists");
                        }
                    }
                    if (text.Length == 4)
                    {
                        Citizen citizen = new Citizen(text[0], int.Parse(text[1]), text[2], text[3]);
                        buyers.Add(citizen);
                    }
                    else if (text.Length == 3)
                    {
                        Rebel rebel = new Rebel(text[0], int.Parse(text[1]), text[2]);
                        buyers.Add(rebel);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (true)
            {
                string name = Console.ReadLine();
                if (name.ToLower() == "end")
                {
                    break;
                }
                foreach (IBuyer buyer in buyers)
                {
                    if (buyer.Name == name)
                    {
                        buyer.BuyFood();
                    }
                }
            }
            int totalFood = 0;
            foreach (IBuyer buyer in buyers)
            {
                totalFood += buyer.Food;
            }
            Console.WriteLine(totalFood);
        }
    }
}
