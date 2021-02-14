using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericBox
{
    public class Box
    {
        public int Swapper<T>(List<T> list, double value)
            where T : IComparable
        {
            int count = 0;
            foreach (T item in list)
            {
                if(item.CompareTo(value)==1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
