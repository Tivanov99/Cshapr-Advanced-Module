using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Tuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;
        public Tuple(T1 first, T2 second)
        {
            this.item1 = first;
            this.item2 = second;
        }
        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
