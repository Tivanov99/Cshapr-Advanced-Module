using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box
    {
        public void Swapper<T>(List<T> list, int[] indexes)
        {
            int FirstIndex = indexes[0];
            int SecondIndex = indexes[1];
            T temp = list[FirstIndex];
            list[FirstIndex] = list[SecondIndex];
            list[SecondIndex] = temp;
            foreach (T item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
