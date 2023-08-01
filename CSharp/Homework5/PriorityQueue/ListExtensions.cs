using System;
using System.Collections.Generic;

namespace CSharp.Homework5.PriorityQueue
{
    public static class ListExtensions
    {
        public static void Sort<T>(this IList<T> list, IComparer<T> comparer)
        {
            Array.Sort(list.ToArray(), comparer);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i];
            }
        }

        public static int BinarySearch<T>(this IList<T> list, T item, IComparer<T> comparer)
        {
            int index = Array.BinarySearch(list.ToArray(), item, comparer);
            return index >= 0 ? index : -1;
        }
    }
}
