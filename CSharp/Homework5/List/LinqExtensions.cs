using System;

namespace CSharp.Homework5.List
{
    public static class LinqExtensions
    {
        public static System.Collections.Generic.IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static System.Collections.Generic.IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (index >= count)
                {
                    yield return item;
                }
                index++;
            }
        }

        public static System.Collections.Generic.IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool stopSkipping = false;
            foreach (var item in source)
            {
                if (!stopSkipping && !predicate(item))
                {
                    stopSkipping = true;
                }
                if (stopSkipping)
                {
                    yield return item;
                }
            }
        }

        public static System.Collections.Generic.IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (index < count)
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
                index++;
            }
        }

        public static System.Collections.Generic.IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            throw new InvalidOperationException("Sequence contains no matching element.");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T lastItem = default(T);
            bool found = false;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastItem = item;
                    found = true;
                }
            }
            if (!found)
            {
                throw new InvalidOperationException("Sequence contains no matching element.");
            }
            return lastItem;
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T lastItem = default(T);
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastItem = item;
                }
            }
            return lastItem;
        }

        public static System.Collections.Generic.IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
    }
}
