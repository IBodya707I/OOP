using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02.Interfaces;

namespace Task_02.Classes
{
    internal class Pet: IBirthdate
    {
        private string name;
        private string birthdate;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }
        public string Birthdate
        {
            get { return birthdate; }
            private set { birthdate = value; }
        }
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
