using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03.Interfaces
{
    internal interface ILeutenantGeneral: ISoldier
    {
        public List<IPrivate> Privates
        {
            get;
        }
        public void AddPrivate(IPrivate privateS);
    }
}
