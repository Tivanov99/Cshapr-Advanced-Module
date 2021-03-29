using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Adapter adapter = new Adapter();
            adapter.Request();
         }
    }
}
