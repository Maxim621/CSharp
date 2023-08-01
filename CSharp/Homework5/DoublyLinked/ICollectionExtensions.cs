

namespace CSharp.Homework5.DoublyLinked
{
    public static class ICollectionExtensions
    {
        public static T[] ToArray<T>(this ICollection<T> collection)
        {
            T[] array = new T[collection.Count];
            int i = 0;
            foreach (T item in collection)
            {
                array[i++] = item;
            }
            return array;
        }

        public static List<T> ToList<T>(this ICollection<T> collection)
        {
            List<T> list = new List<T>(collection.Count);
            foreach (T item in collection)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
