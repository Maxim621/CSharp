

namespace CSharp.Homework5.DoublyLinked
{
    public static class IEnumerableExtensions
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
                    skipped++;
                else
                    yield return item;
            }
        }

        public static IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool yielding = false;
            foreach (T item in source)
            {
                if (!yielding && predicate(item))
                    continue;
                yielding = true;
                yield return item;
            }
        }
    }
}
