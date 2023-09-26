using System;
using System.Collections.Generic;

namespace CSharp.Homework5.Tree
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            int index = 0;
            foreach (T item in source)
            {
                if (index >= count)
                    yield return item;
                index++;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool skip = true;
            foreach (T item in source)
            {
                if (!skip || !predicate(item))
                {
                    yield return item;
                    skip = false;
                }
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            int index = 0;
            foreach (T item in source)
            {
                if (index < count)
                    yield return item;
                else
                    yield break;
                index++;
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    yield return item;
                else
                    yield break;
            }
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    return item;
            }
            throw new InvalidOperationException("Sequence contains no matching element");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    return item;
            }
            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T foundItem = default(T);
            bool found = false;

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    foundItem = item;
                    found = true;
                }
            }

            if (!found)
                throw new InvalidOperationException("Sequence contains no matching element");

            return foundItem;
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T foundItem = default(T);

            foreach (T item in source)
            {
                if (predicate(item))
                    foundItem = item;
            }

            return foundItem;
        }
    }
}
