using System;
using System.Collections.Generic;

namespace CSharp.Homework5.PriorityQueue
{
    public static class MyLinqExtensionsWithYield
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
            int skipped = 0;
            foreach (T item in source)
            {
                if (skipped < count)
                {
                    skipped++;
                    continue;
                }
                yield return item;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool skip = true;
            foreach (T item in source)
            {
                if (skip && predicate(item))
                    continue;

                skip = false;
                yield return item;
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            int taken = 0;
            foreach (T item in source)
            {
                if (taken < count)
                {
                    taken++;
                    yield return item;
                }
                else
                {
                    break;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    yield return item;
                else
                    break;
            }
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    return item;
            }

            throw new InvalidOperationException("No matching element found");
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
            T lastMatch = default(T);
            bool foundMatch = false;

            foreach (T item in source)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                    foundMatch = true;
                }
            }

            if (!foundMatch)
                throw new InvalidOperationException("No matching element found");

            return lastMatch;
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T lastMatch = default(T);

            foreach (T item in source)
            {
                if (predicate(item))
                    lastMatch = item;
            }

            return lastMatch;
        }
    }
}
