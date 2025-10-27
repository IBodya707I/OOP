using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01.Classes
{
    internal class ListyIterator<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator()
        {
            this.items = new List<T>();
            this.index = 0;
        }
        public void AddList(T[] list) 
        {
            items = new List<T>(list); 
        }
        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return this.index < this.items.Count - 1;
        }
        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.items[this.index]);
        }
    }
}
