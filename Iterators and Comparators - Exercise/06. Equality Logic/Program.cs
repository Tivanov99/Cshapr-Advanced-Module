using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> set = new SortedSet<Person>();
            HashSet<Person> hash = new HashSet<Person>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                Person person = new Person(input);
                    set.Add(person);
                if (person.IsTheSame != true)
                {
                    hash.Add(person);
                }
            }
            Console.WriteLine(set.Count());
            Console.WriteLine(hash.Count());

        }
    }
}
