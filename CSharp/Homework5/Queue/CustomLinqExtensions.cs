namespace CSharp.Homework5.Queue
{
    public static class CustomLinqExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Skip<T>(this IEnumerable<T> collection, int count)
        {
            int skipped = 0;

            foreach (var item in collection)
            {
                if (skipped < count)
                {
                    skipped++;
                }
                else
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            bool shouldSkip = true;

            foreach (var item in collection)
            {
                if (shouldSkip && predicate(item))
                {
                    continue;
                }

                shouldSkip = false;
                yield return item;
            }
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
        {
            int taken = 0;

            foreach (var item in collection)
            {
                if (taken < count)
                {
                    yield return item;
                    taken++;
                }
                else
                {
                    break;
                }
            }
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    break;
                }
            }
        }

        public static T First<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static T Last<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            T lastMatch = default(T);
            bool foundMatch = false;

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return lastMatch;
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static T LastOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            T lastMatch = default(T);

            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    lastMatch = item;
                }
            }

            return lastMatch;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> selector)
        {
            foreach (var item in collection)
            {
                yield return selector(item);
            }
        }

        public static bool All<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static T[] ToArray<T>(this IEnumerable<T> collection)
        {
            var result = new List<T>();
            foreach (var item in collection)
            {
                result.Add(item);
            }
            return result.ToArray();
        }

        public static List<T> ToList<T>(this IEnumerable<T> collection)
        {
            var result = new List<T>();
            foreach (var item in collection)
            {
                result.Add(item);
            }
            return result;
        }
    }
}