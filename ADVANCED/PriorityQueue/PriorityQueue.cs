using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        List<T> priorityQueue;
        public PriorityQueue()
        {
            priorityQueue = new List<T>();
        }
        public int Size => priorityQueue.Count;

        public T Dequeue()
        {
            ValidateNotEmpty();
            T firstElement = this.priorityQueue[0];
            Swap(0, this.priorityQueue.Count - 1);
            this.priorityQueue.RemoveAt(this.priorityQueue.Count - 1);
            this.HeapiFyDown(0);
            return firstElement;
        }

        public void Add(T element)
        {
            this.priorityQueue.Add(element);
            HeapifyUp(priorityQueue.Count - 1);
        }
        private bool ValidateIndex(int index)
        {
            return index <= this.priorityQueue.Count - 1;
        }
        private void ValidateNotEmpty()
        {
            if (this.priorityQueue.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
        private void HeapiFyDown(int index)
        {
            int leftChild = GetLeftChildIndex(index);
            while (ValidateIndex(leftChild) && !IsGreater(index, leftChild))
            {
                int ToSwapWith = leftChild;
                int RightChild = GetRightChildIndex(index);
                if (ValidateIndex(RightChild) && !IsGreater(ToSwapWith, RightChild))
                {
                    ToSwapWith = RightChild;
                }
                Swap(index, ToSwapWith);
                index = ToSwapWith;
                leftChild = GetLeftChildIndex(leftChild);
            }
        }
        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void HeapifyUp(int index)
        {
            int ParentIndex = GetParentIndex(index);
            while (index > 0 && IsGreater(index, ParentIndex))
            {
                Swap(index, ParentIndex);
                index = ParentIndex;
                ParentIndex = GetParentIndex(index);
            }
        }
        private bool IsGreater(int index, int parentIndex)
        {
            return this.priorityQueue[index].CompareTo(this.priorityQueue[parentIndex]) == 1;
        }
        public T Peek()
        {
            return this.priorityQueue[0];
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        private void Swap(int index, int parentIndex)
        {
            T temp = this.priorityQueue[index];
            this.priorityQueue[index] = this.priorityQueue[parentIndex];
            this.priorityQueue[parentIndex] = temp;
        }
    }
}
