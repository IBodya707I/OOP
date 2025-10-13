using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Classes;

namespace Task_02
{
    internal class Part_01
    {
        public static void Run()
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();
            while (true)
            {
                string[] text = Console.ReadLine().Split();
                if (text[0].ToLower() == "end")
                {
                    break;
                }
                else if (text.Length == 3)
                {
                    Citizen citizen = new Citizen(text[0], int.Parse(text[1]), text[2]);
                    citizens.Add(citizen);
                }
                else if (text.Length == 2)
                {
                    Robot robot = new Robot(text[0], text[1]);
                    robots.Add(robot);
                }
            }
            string code = Console.ReadLine();
            for(int i = 0; i < citizens.Count; i++)
            {
                if(citizens[i].IsFakeId(code))
                {
                    Console.WriteLine(citizens[i].Id);
                }

            }
            for(int i = 0;i < robots.Count; i++)
            {
                if (robots[i].IsFakeId(code))
                {
                    Console.WriteLine(robots[i].Id);
                }
            }
        }
    }
}
