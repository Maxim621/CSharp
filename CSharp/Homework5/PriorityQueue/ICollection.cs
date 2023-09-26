using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Homework5.PriorityQueue
{
    public interface ICollection<T> : IEnumerable<T>
    {
        int Count { get; }
        void Add(T item);
        bool Remove(T item);
        void Clear();
        bool Contains(T item);
    }

    public interface IList<T> : ICollection<T>
    {
        T this[int index] { get; set; }
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
    }
}
