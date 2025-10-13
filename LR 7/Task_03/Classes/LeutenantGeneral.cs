using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class LeutenantGeneral: Private, ILeutenantGeneral
    {
        private List<IPrivate> privates;
        public List<IPrivate> Privates
        {
            get { return privates; }
            private set { privates = value; }
        }
        public LeutenantGeneral(string id, string firstName, string lastName, double salary): base(id, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>();
        }
        public void AddPrivate(IPrivate p)
        {
            Privates.Add(p);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var pr in Privates)
            {
                sb.AppendLine("  " + pr.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
