﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    public interface IAbstractHeap<T>
        where T : IComparable<T>
    {
        int Size { get; }

        void Add(T element);

        T Peek();

        T Dequeue();
    }
}
