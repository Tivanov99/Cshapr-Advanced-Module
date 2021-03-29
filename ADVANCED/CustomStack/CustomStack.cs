using System;
using System.Collections.Generic;
using System.Text;

namespace CustomeStack
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;
        public CustomStack()
        {
            count = 0;
            items = new int[InitialCapacity];
        }
        public int Count
        {
            get { return count; }
        }
        public void Push(int element)
        {
            if (items.Length == count)
            {
                Resize();
            }
            items[count] = element;
            count++;
        }
        private void Resize()
        {
            int[] ResizedArray = new int[items.Length * 2];
            for (int i = 0; i < count; i++)
            {
                ResizedArray[i] = items[i];
            }
            items = ResizedArray;
        }
        public int Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }
            int lastItem = items[count - 1];
            int[] coppy = new int[count - 1];
            for (int i = 0; i < count; i++)
            {
                coppy[i] = items[i];
            }
            items = coppy;
            return lastItem;
        }
        public int Peek()
        {
            return items[count - 1];
        }
        public void ForEach(Action<object>action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }
    }
}
