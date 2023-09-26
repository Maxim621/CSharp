using System;
using System.Collections.Generic;

namespace CSharp.Homework5.ObservableList
{
    public static class IEnumerableExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                yield return item;
            }
        }
    }
}
