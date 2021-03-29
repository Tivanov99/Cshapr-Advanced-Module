using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public class Owner : IOwner
    {
        public void Request()
        {
            Console.WriteLine($"");
        }
    }
}
