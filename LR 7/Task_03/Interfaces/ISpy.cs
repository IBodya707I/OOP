using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Interfaces
{
    internal interface ISpy: ISoldier
    {
        public string CodeNumber
        {
            get;
        }
    }
}
