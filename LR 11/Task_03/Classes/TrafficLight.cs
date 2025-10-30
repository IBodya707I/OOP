using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    internal class TrafficLight
    {
        private List<string> colors = new List<string>();
        public TrafficLight(List<string> c)
        { 
            colors = c;
        }
        private string NextColor(string current)
        {
            if(current == "Green")
            {
                return "Yellow";
            }
            else if(current == "Yellow")
            {
                return "Red";
            }
            else if(current == "Red")
            {
                return "Green";
            }
            return "";
        }
        public void MoveLights(int n)
        {
            string color = colors[0];
            List<string> c = colors;
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < colors.Count; j++)
                {
                    c[j] = NextColor(c[j]);
                    Console.Write(c[j] + " ");

                }   
                Console.WriteLine();
            }
        }
    }
}
