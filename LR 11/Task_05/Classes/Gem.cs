using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.Classes
{
    internal class Gem
    {
        private string type;
        private int strength;
        private int agility;
        private int vitality;
        public string Type
        {
            get { return type; }
            private set { type = value; }
        }
        public int Strength
        {
            get { return strength; }
            private set {  strength = value; }
        }
        public int Agility
        {
            private set { agility = value; }
            get { return agility; }
        }
        public int Vitality
        {
            get { return vitality; }
            private set { vitality = value; }
        }
        public Gem(string type, string clarity)
        {
            Type = type;
            switch(type)
            {
                case "Ruby":
                    Strength = 7;
                    Agility = 2;
                    Vitality = 5;
                    break;
                case "Emerald":
                    Strength = 1;
                    Agility = 4;
                    Vitality = 9;
                    break;
                case "Amethyst":
                    Strength = 2;
                    Agility = 8;
                    Vitality = 4;
                    break;
            }
            switch(clarity)
            {
                case "Chipped":
                    Strength += 1;
                    Agility += 1;
                    Vitality += 1;
                    break;
                case "Regular":
                    Strength += 2;
                    Agility += 2;
                    Vitality += 2;
                    break;
                case "Perfect":
                    Strength += 5;
                    Agility += 5;
                    Vitality += 5;
                    break;
                case "Flawless":
                    Strength += 10;
                    Agility += 10;
                    Vitality += 10;
                    break;
            }

        }


    }
}
