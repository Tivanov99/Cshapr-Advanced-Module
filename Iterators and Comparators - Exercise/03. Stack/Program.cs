using System;
using System.Collections.Generic;

namespace Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Replace("Push", ", ");
            string[] da = input.Split(", ");
            CustumeStack<int> stack = new CustumeStack<int>();
            for (int i = 1; i < da.Length; i++)
            {
                stack.Push(int.Parse(da[i]));
            }
            while (true)
            {
                string[] comand = Console.ReadLine().Split();
                if (comand[0] == "END")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        foreach (var item in stack)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                }
                else if (comand[0] == "Pop")
                {
                    stack.Pop();
                }
                else if (comand[0] == "Push")
                {
                    int num = int.Parse(comand[1]);
                    stack.Push(num);
                }
            }

        }
    }
}
