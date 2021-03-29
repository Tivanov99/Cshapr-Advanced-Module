using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;
    private T[] queue;
    private int endIndex;
    private int startIndex;
    public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.queue = new T[DefaultCapacity];
        this.Count = 0;
    }

    public void Enqueue(T element)
    {
        if (this.Count >= queue.Length)
        {
            this.Resize();
        }
        this.queue[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.queue.Length;
        Count++;
    }

    private void Resize()
    {
        T[] newArray = new T[queue.Length * 2];
        CopyAllElements(newArray);
        this.queue = newArray;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElements(T[] newArray)
    {
        int sourceindex = this.startIndex;
        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.queue[sourceindex];
            sourceindex = (sourceindex + 1) % this.queue.Length;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty!");
        }
        T result = this.queue[startIndex];
        this.startIndex = (startIndex + 1) % this.queue.Length;
        Count--;
        return result;
    }

    public T[] ToArray()
    {
        T[] newArray = new T[Count];
        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = queue[i];
        }
        return newArray;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
