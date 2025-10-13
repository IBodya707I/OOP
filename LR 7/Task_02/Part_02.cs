using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Classes;
using Task_02.Interfaces;
namespace Task_02
{
    internal class Part_02
    {
        public static void Run()
        {
            List<IBirthdate> birthdates = new List<IBirthdate>();
            while (true)
            {
                string[] text = Console.ReadLine().Split();
                if (text[0].ToLower() == "end")
                {
                    break;
                }
                else if (text[0].ToLower() == "citizen")
                {
                    Citizen citizen = new Citizen(text[1], int.Parse(text[2]), text[3], text[4]);
                    birthdates.Add(citizen);
                }
                else if (text[0].ToLower() == "pet")
                {
                    Pet pet = new Pet(text[1], text[2]);
                    birthdates.Add(pet);
                }
            }
            string year = Console.ReadLine();
            for (int i = 0; i < birthdates.Count; i++)
            {
                if (birthdates[i].Birthdate.EndsWith(year))
                {
                    Console.WriteLine(birthdates[i].Birthdate);
                }
            }
        }
    }
}
