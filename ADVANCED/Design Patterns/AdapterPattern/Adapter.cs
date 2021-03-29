using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public class Adapter : IOwner
    {
        private readonly Sklad sklad;
        public Adapter()
        {
            sklad = new Sklad();
        }
        private string input;
        public void Request()
        {
            Console.WriteLine($"Enter name of Component: ");
            input = Console.ReadLine();
            Console.WriteLine(sklad.ContainsAnyComponent(input));

        }
    }
}
