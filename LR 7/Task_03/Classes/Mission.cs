using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Classes
{
    internal class Mission
    {
        private string codeName;
        private string state;
        public string CodeName
        {
            get { return codeName; }
            private set { codeName = value; }
        }
        public string State
        {
            get { return state; }
            private set 
            { 
                if (value == "inProgress" || value == "Finished")
                {
                    state = value; 
                }
            }
        }
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }
        public void CompleteMission()
        {
            State = "Finished";
        }
        public override string ToString()
        {
            return ("Code Name: " + CodeName + " State: " + State);
        }
    }
}
