

namespace CSharp.Homework5.Stack
{
    public interface IStack<T>
    {
        void Clear();
        bool Contains(T item);
        T Peek();
        T[] ToArray();
        void Push(T item);
        T Pop();
        int Count { get; }
    }
}
