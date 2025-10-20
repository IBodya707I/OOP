using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_09.Classes
{
    internal static class Sorting
    {
        public static void Sort<T>(CustomList<T> list) where T : IComparable<T>
        {
            for(int i = 0;i < list.list.Count - 1;i++)
            {
                for(int j = 1;j < list.list.Count;j++)
                {
                    if (list.list[i].CompareTo(list.list[j]) > 0)
                    {
                        T x = list.list[i];
                        list.list[i] = list.list[j];
                        list.list[j] = x;
                    }
                }
            }
        }
    }
}
