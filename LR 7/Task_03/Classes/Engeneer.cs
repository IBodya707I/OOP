using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class Engeneer: SpecialSoldier, IEngeneer
    {
        private List<Repair> repairs;
        public List<Repair> Repairs
        {
            get { return repairs; }
            private set { repairs = value; }
        }
        public Engeneer(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<Repair>();
        }
        public void AddRepair(Repair repair)
        {
            Repairs.Add(repair);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
