using System.Collections.Generic;


namespace CSharp.Homework5.Linked
{
    public interface ICollection<T> : IEnumerable<T>
    {
        int Count { get; }
        void Add(T item);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}
