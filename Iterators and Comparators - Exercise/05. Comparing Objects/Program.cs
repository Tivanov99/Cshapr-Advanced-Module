using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> coll = new List<Person>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (input[0] == "END")
                {
                    break;
                }
                Person person = new Person(input);
                coll.Add(person);
            }
            int num = int.Parse(Console.ReadLine());
            Person comparePerson = coll[num - 1];
            int samePll = 0;
            foreach (Person item in coll)
            {
                if (item.CompareTo(comparePerson) == 0)
                {
                    samePll++;
                }
            }
            if (samePll == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{samePll} {coll.Count-samePll} {coll.Count}");
            }
        }
    }
}
