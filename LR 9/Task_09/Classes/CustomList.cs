using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_09.Classes
{
    public class CustomList<T> where T : IComparable<T>
    {
        public List<T> list;
        public CustomList()
        {
            list = new List<T>();
        }
        public void Add(T item)
        {
            list.Add(item);
        }
        public void Remove(int index)
        {
            list.RemoveAt(index);
        }
        public bool Contains(T item)
        {
            if(list.Contains(item)) 
                return true;
            else
                return false;
        }
        public void Swap(int i1, int i2)
        {
            T x = list[i1]; 
            list[i1] = list[i2];
            list[i2] = x;
        }
        public int CountGreaterThan(T item)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(item) > 0)
                    count++;
            }
            return count;
        }
        public T Max()
        {
            T max = list.Max();
            return max;
        }
        public T Min()
        {
            T min = list.Min();
            return min;
        }
        public void Print()
        {
            for(int i = 0; i < list.Count;i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
