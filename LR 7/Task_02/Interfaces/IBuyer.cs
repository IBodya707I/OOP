using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02.Interfaces
{
    internal interface IBuyer
    {
        public int Food
        {
            get;
        }
        public string Name { get; }
        public void BuyFood();
    }
}
