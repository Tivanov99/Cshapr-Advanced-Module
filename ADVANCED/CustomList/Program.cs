using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(5);
            list.Add(10);
            list.Add(30);
            list.Add(3);
            list.Add(1);
            list.Add(100);
            list.Add(75);
            list.Add(9);
            list.Add(38);
            list.Add(64);
            list.Add(999);

          
            list.Swap(5, 10);
        }
    }
}
