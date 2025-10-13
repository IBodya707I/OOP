using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class SpecialSoldier: Private, ISpecialSoldier
    {
        private string corps;
        public string Corps
        {
            get { return corps; }
            private set 
            {
                if (value.ToLower() != "airforces" && value.ToLower() != "marines")
                {
                    throw new ArgumentException("Invalid corps!");
                }
                corps = value; 
            }
        }
        public SpecialSoldier(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

    }
}
