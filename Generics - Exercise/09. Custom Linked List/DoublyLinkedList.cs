using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> Head;
        private ListNode<T> Tail;

        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                this.Head = new ListNode<T>(element);
                this.Tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                newHead.NextNode = Head;
                Head.PreviousNode = newHead;
                Head = newHead;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                Head = new ListNode<T>(element);
                Tail = new ListNode<T>(element);
            }
            else
            {
                var NewTail = new ListNode<T>(element);
                NewTail.PreviousNode = Tail;
                Tail.NextNode = NewTail;
                Tail = NewTail;
            }
            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var firstelement = Head.Value;
            Head = Head.NextNode;
            if (Head != null)
            {
                Head.PreviousNode = null;
            }
            else
            {
                Tail = null;
            }
            this.Count--;
            return firstelement;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var LastElement = Tail.Value;
            Tail = Tail.PreviousNode;
            if (Tail != null)
            {
                Tail.NextNode = null;
            }
            else
            {
                Head = null;
            }
            Count--;
            return LastElement;
        }
        public void ForEach(Action<T> Action)
        {
            var currNode = Head;
            while (currNode != null)
            {
                Action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            var Currnode = Head;
            while (Currnode != null)
            {
                array[counter] = Currnode.Value;
                Currnode = Currnode.NextNode;
                counter++;
            }
            return array;
        }
    }
}
