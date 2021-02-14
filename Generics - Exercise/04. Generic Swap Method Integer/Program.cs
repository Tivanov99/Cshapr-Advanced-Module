using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box();
            int count = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(input);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.Swapper(list, indexes);
        }
    }
}
