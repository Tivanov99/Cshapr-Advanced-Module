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
            string city = "";
            for (int i = 3; i < names.Length; i++)
            {
                city += names[i]+ " ";
            }
            city.TrimEnd();
            Threeuple<string, string, string> tupple = new Threeuple<string, string, string>(firstname, names[2], city);
            Console.WriteLine(tupple.ToString());
            names = Console.ReadLine().Split();
            Threeuple<string, int, string> Second = new Threeuple<string, int, string>(names[0], int.Parse(names[1]), names[2]);
            Console.WriteLine(Second.Drink());
            names = Console.ReadLine().Split();
            Threeuple<string, double, string> Third = new Threeuple<string, double, string>(names[0], double.Parse(names[1]), names[2]);
            Console.WriteLine(Third.ToString());
        }
    }
}
