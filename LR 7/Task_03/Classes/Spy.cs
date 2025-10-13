using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class Spy: Soldier, ISpy
    {
        private string codeNumber;
        public string CodeNumber
        {
            get { return codeNumber; }
            private set { codeNumber = value; }
        }
        public Spy(string id, string firstName, string lastName, string codeNumber): base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }
        public override string ToString()
        {
            return (base.ToString() + " Code Number: " + CodeNumber);
        }
    }
}
