using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_03.Interfaces;
namespace Task_03.Classes
{
    internal class Commando: SpecialSoldier, ICommando
    {
        List<Mission> missions;
        public List<Mission> Missions
        {
            get { return missions; }
            private set { missions = value; }
        }
        public Commando(string id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            Missions = new List<Mission>();
        }
        public void AddMission(Mission mission)
        {
            Missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Corps: " + Corps);
            sb.AppendLine("Missions:");
            foreach(Mission mission in Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
