using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class CustumeStack<T> : IEnumerable<T>
    {
        public Stack<T> stack;
        public CustumeStack()
        {
            stack = new Stack<T>();
        }
        public void Push(T element)
        {
            stack.Push(element);
        }
        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in stack)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
