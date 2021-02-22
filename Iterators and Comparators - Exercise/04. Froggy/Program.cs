using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int length = input.Length;
            Lake lake = new Lake(input);
            foreach (int item in lake)
            {
                length--;
                if (length == 0)
                {
                    Console.Write(item+ " ");
                }
                else
                {
                    Console.Write(item + ", ");
                }
            }
        }
    }
}
