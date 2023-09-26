using System.Collections.Generic;

namespace CSharp.Homework5.Linked
{
    public interface IList<T> : ICollection<T>
    {
        T this[int index] { get; set; }
        void Insert(int index, T item);
    }
}
