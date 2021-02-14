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
            List<double> list = new List<double>();
            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }
            double Value = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Swapper(list, Value));
        }
    }
}
