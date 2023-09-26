using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Homework5.ObservableList
{
    public static class YieldLinqExtensions
    {
        public static IEnumerable<T> YieldFilter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> YieldSkip<T>(this IEnumerable<T> source, int count)
        {
            int skipped = 0;
            foreach (var item in source)
            {
                if (skipped < count)
                {
                    skipped++;
                    continue;
                }
                yield return item;
            }
        }

        public static IEnumerable<T> YieldSkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool skip = true;
            foreach (var item in source)
            {
                if (skip && predicate(item))
                {
                    continue;
                }
                skip = false;
                yield return item;
            }
        }

        public static IEnumerable<T> YieldTake<T>(this IEnumerable<T> source, int count)
        {
            int taken = 0;
            foreach (var item in source)
            {
                if (taken < count)
                {
                    yield return item;
                    taken++;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<T> YieldTakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
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

        public static T YieldFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            throw new InvalidOperationException("Sequence contains no matching elements.");
        }

        public static T YieldFirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default;
        }

        public static T YieldLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T lastMatch = default;
            bool found = false;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                    found = true;
                }
            }
            if (!found)
            {
                throw new InvalidOperationException("Sequence contains no matching elements.");
            }
            return lastMatch;
        }

        public static T YieldLastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T lastMatch = default;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                }
            }
            return lastMatch;
        }

        public static IEnumerable<TResult> YieldSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> YieldSelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var item in source)
            {
                foreach (var result in selector(item))
                {
                    yield return result;
                }
            }
        }

        public static bool YieldAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool YieldAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static T[] YieldToArray<T>(this IEnumerable<T> source)
        {
            var list = new List<T>(source);
            return list.ToArray();
        }

        public static List<T> YieldToList<T>(this IEnumerable<T> source)
        {
            return new List<T>(source);
        }
    }
}
