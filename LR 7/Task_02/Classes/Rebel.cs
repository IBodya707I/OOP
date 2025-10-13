using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Interfaces;
namespace Task_02.Classes
{
    internal class Rebel: IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food = 0;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }
        public string Group
        {
            get { return group; }
            private set { group = value; }
        }
        public int Food
        {
            get { return food; }
            private set { food = value; }
        }
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
