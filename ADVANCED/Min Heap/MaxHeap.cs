using System;
using System.Collections.Generic;
using System.Text;

namespace MaxHeap
{
    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        List<T> Heap;
        public MaxHeap()
        {
            Heap = new List<T>();
        }
        public int Size => Heap.Count;

        public void Add(T element)
        {
            Heap.Add(element);
            HeapyifyUP(Heap.Count - 1);
        }

        public T Peek()
        {
            if (Heap.Count > 0)
            {
                return Heap[0];
            }
            throw new InvalidOperationException();
        }
        private void HeapyifyUP(int index)
        {
            int parentIndex = GetParentIndex(index);
            while (index > 0 && isLower(index, parentIndex))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }
        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int index, int ParentIndex)
        {
            T temp = Heap[index];
            Heap[index] = Heap[ParentIndex];
            Heap[ParentIndex] = temp;
        }

        private bool isLower(int index, int parentIndex)
        {
            if (Heap[index].CompareTo(Heap[parentIndex]) == -1)
            {
                return true;
            }
            return false;
        }
    }
}
