using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04.Classes
{
    internal class Weapon
    {
        private string name;
        private Gem[] gems;
        private int socketCount;
        private int minPower;
        private int maxPower;
        public string Name
        {
            get { return name; } 
            private set { name = value; }
        }
        public int MinPower
        {
            get { return minPower; }
            private set { minPower = value; }
        }
        public int MaxPower
        {
            get { return maxPower; }
            private set { maxPower = value; }
        }
        public Weapon(string name, string type, string rariry)
        {
            Name = name;
            switch (type)
            {
                case "Axe":
                    MinPower = 5;
                    MaxPower = 10;
                    socketCount = 4;
                    break;
                case "Sword":
                    MinPower = 4;
                    MaxPower = 6;
                    socketCount = 3;
                    break;
                case "Knife":
                    MinPower = 3;
                    MaxPower = 4;
                    socketCount = 2;
                    break;

            }
            switch(rariry)
            {
                case "Common":
                    MinPower *= 1;
                    MaxPower *= 1;
                    break;
                case "Uncommon":
                    MinPower *= 2;
                    MaxPower *= 2;
                    break;
                case "Rare":
                    MinPower *= 3;
                    MaxPower *= 3;
                    break;
                case "Epic":
                    MinPower *= 5;
                    MaxPower *= 5;
                    break;
            }
            gems = new Gem[socketCount];
        }
        public void AddGem(Gem gem, int socketIndex)
        {
            if(socketIndex < socketCount && gems[socketIndex] == null)
            {
                gems[socketIndex] = gem;
            }
        }
        public void RemoveGem(int socketIndex)
        {
            if(socketIndex < socketCount && gems[socketIndex] != null)
            {
                gems[socketIndex] = null;
            }
        }
        public override string ToString()
        {
            int totalStrenght = 0;
            int totalAgility = 0;
            int totalVitality = 0;
            foreach (var gem in gems)
            {
                if (gem != null)
                {
                    totalStrenght += gem.Strength;
                    totalAgility += gem.Agility;
                    totalVitality += gem.Vitality;
                }
            }
            int finalMinPower = MinPower + (totalStrenght * 2) + (totalAgility);
            int finalMaxPower = MaxPower + (totalStrenght * 3) + (totalAgility * 4);
            return $"{Name}: {finalMinPower}-{finalMaxPower} Damage, +{totalStrenght} Strenght, +{totalAgility} Agility, +{totalVitality} Vitality";
        }
    }
}
