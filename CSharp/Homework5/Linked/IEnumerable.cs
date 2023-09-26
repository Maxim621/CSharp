using System.Collections.Generic;

namespace CSharp.Homework5.Linked
{
    public interface IEnumerable<T>
    {
        IEnumerator<T> GetEnumerator();
    }
}
