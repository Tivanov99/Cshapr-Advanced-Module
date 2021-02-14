using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            string firstname = names[0] + " " + names[1];
            Tuple<string, string> tupple = new Tuple<string, string>(firstname, names[2]);
            Console.WriteLine(tupple.ToString());
            names = Console.ReadLine().Split();
            Tuple<string, int> Second = new Tuple<string, int>(names[0], int.Parse(names[1]));
            Console.WriteLine(Second.ToString());
            names = Console.ReadLine().Split();
            Tuple<int, double> Third = new Tuple<int, double>(int.Parse(names[0]), double.Parse(names[1]));
            Console.WriteLine(Third.ToString());
        }
    }
}
