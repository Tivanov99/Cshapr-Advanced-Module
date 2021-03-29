using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            items = new int[InitialCapacity];
        }
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }
        private void Resize()
        {
            int[] ResizedArray = new int[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                ResizedArray[i] = items[i];
            }
            items = ResizedArray;
        }
        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }
            items[Count] = element;
            Count++;
        }
        public int RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int ValueOfIndex = items[index];
            items[index] = default(int);
            Shift(index);
            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }
            return ValueOfIndex;
        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] ShrinkedArry = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                ShrinkedArry[i] = items[i];
            }
            items = ShrinkedArry;
        }
        public void Insert(int index, int item)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (items.Length == Count)
            {
                Resize();
            }
            int MiddleofArray = items.Length / 2;
            ShiftToLeft(index, item);
            Count++;
        }
        private void ShiftToLeft(int index, int element)
        {
            int[] NewArray = new int[items.Length];
            for (int i = 0; i < index; i++)
            {
                NewArray[i] = items[i];
            }
            NewArray[index] = element;
            for (int i = index; i <= Count; i++)
            {
                NewArray[i + 1] = items[i];
            }
            items = NewArray;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int FirstIndex, int Secoundindex)
        {
            if (FirstIndex < 0 || FirstIndex > Count || Secoundindex < 0 || Secoundindex > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int tempofFirst = items[FirstIndex];
            items[FirstIndex] = items[Secoundindex];
            items[Secoundindex] = tempofFirst;
        }
    }
}
