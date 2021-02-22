using System;
using System.Collections.Generic;

namespace Exercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string[] coppy = new string[input.Length - 1];
            for (int i = 1; i < input.Length; i++)
            {
                coppy[i - 1] = input[i];
            }
            ListyIterator<string> listy = new ListyIterator<string>(coppy);

            while (true)
            {
                string[] Comands = Console.ReadLine().Split();
                if (Comands[0] == "END")
                {
                    break;
                }
                else if (Comands[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (Comands[0] == "Print")
                {
                    listy.Print();
                }
                else if (Comands[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if(Comands[0]== "PrintAll")
                {
                   listy.PRINT();
                }
            }

        }
    }
}
