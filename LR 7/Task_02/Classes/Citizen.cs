using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Interfaces;

namespace Task_02.Classes
{
    internal class Citizen: IFakeId, IBirthdate, IBuyer
    {
        string name;
        int age;
        string id;
        string birthdate = "";
        int food = 0;
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
        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Birthdate
        {
            get { return birthdate; }
            private set { birthdate = value; }
        }
        public int Food
        {
            get { return food; }
            private set { food = value; }
        }
        public Citizen(string name, int age, string id, string birthdate = "")
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }
        public bool IsFakeId(string code)
        {
            int x = 0;
            for (int i = id.Length - code.Length; i < id.Length; i++)
            {
                if (id[i] != code[x])
                {
                    return false;
                }
                x++;
            }
            return true;
        }
        public void BuyFood()
        {
            Food += 10;
        }
    }
}
