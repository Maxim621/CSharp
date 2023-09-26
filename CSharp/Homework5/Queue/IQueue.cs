

namespace CSharp.Homework5.Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        void Clear();
        bool Contains(T item);
        T Peek();
        T[] ToArray();
        int Count { get; }
    }
}
