using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework5.Linked
{
    public interface ILinkedList<T> : IList<T>
    {
        void AddFirst(T item);
    }
}
