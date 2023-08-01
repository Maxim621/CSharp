using System;
using System.Collections.Generic;

namespace CSharp.Homework5.PriorityQueue
{
    public class PriorityQueue<T>
    {
        private List<T> items = new();
        private IComparer<T> comparer;

        public PriorityQueue()
        {
            comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count => items.Count;

        public void Enqueue(T item)
        {
            items.Add(item);
            items.Sort(comparer);
        }

        public T Dequeue()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return items[0];
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }
    }
}
