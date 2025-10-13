using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class Soldier: ISoldier
    {
        private string id;
        private string firstName;
        private string lastName;
        public string Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            private set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            private set { lastName = value; }
        }
        public Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return ("Name: " + FirstName + " " + LastName + " Id: " + Id);
        }
    }
}
