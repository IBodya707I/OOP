using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04.Classes
{
    internal class NameComporator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int lengthComparison = x.Name.Length.CompareTo(y.Name.Length);
            if (lengthComparison != 0)
            {
                return lengthComparison;
            }
            int firstCharComparison = x.Name[0].CompareTo(y.Name[0]);
            return firstCharComparison;
        }
    }
}
