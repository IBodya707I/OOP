using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Classes;
namespace Task_03.Interfaces
{
    internal interface IEngeneer: ISoldier
    {
        public List<Repair> Repairs
        {
            get;
        }
        public void AddRepair(Repair repair);
    }
}
