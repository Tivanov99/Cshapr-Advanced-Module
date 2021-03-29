using System;
using System.Collections;

namespace CustomeStack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            stack.Push(1);
            stack.Push(95);
            stack.Push(83);
            stack.Push(37);
            stack.Push(92);
            stack.Push(19);
            stack.Push(24);
            stack.Push(62);
            stack.Peek();
            stack.Pop();
            
        }
    }
}
