using System.Collections.Generic;

namespace CSharp.Homework5.List
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
