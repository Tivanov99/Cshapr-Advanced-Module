using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListImplementation
{
    public class LinkedListImplement
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; private set; }
        public void AddFirst(Node node)
        {
            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Head.Next = Head;
                Head.Previous = node;
                Head = node;
            }
            Count++;
        }
        public void AddLast(Node node)
        {
            if (Count == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Previous = Tail;
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }
        public Node RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            Node currhead = Head;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            Count--;
            return currhead;
        }
        public Node RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            Node lastElement = Tail;
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return lastElement;
        }
        public void ForEach(Action<int> action)
        {
            var currNode = Head;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.Next;
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            var CurrNode = Head;
            while (CurrNode != null)
            {
                array[counter] = CurrNode.Value;
                CurrNode = CurrNode.Next;
            }
            return array;
        }
    }
}
