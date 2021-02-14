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
            List<string> list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }
            string Value = Console.ReadLine();
            Console.WriteLine(box.Swapper(list, Value));
        }
    }
}
