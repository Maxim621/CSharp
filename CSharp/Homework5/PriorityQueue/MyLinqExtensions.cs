using System;
using System.Collections.Generic;

namespace CSharp.Homework5.PriorityQueue
{
    public static class MyLinqExtensions
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

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (T item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this IEnumerable<T> source, Func<T, IEnumerable<TResult>> selector)
        {
            foreach (T item in source)
            {
                foreach (TResult result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (!predicate(item))
                    return false;
            }
            return true;
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }

        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            List<T> list = new List<T>(source);
            return list.ToArray();
        }

        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            return new List<T>(source);
        }
    }
}
