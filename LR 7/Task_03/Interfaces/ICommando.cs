using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Classes;
namespace Task_03.Interfaces
{
    internal interface ICommando: ISoldier
    {
        List<Mission> Missions
        {
            get;
        }
        public void AddMission(Mission mission);
    }
}
