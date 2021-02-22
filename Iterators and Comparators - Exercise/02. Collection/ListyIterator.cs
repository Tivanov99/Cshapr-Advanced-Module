using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Exercise
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> MyList;
        private int index;
        public ListyIterator(params T[] input)
        {
            MyList = new List<T>(input);
        }

        public bool Move()
        {
            if (index < MyList.Count-1)
            {
                this.index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            return index+1 < MyList.Count;
        }
        public void Print()
        {
            if (MyList.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(MyList[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in MyList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PRINT()
        {
            foreach (T item in MyList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
