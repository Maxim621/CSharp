using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Homework5.Linked
{ 
    public static class LinqExtensions
    {
        public static System.Collections.Generic.IEnumerable<IEnumerable<T>> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return (IEnumerable<T>)item;
            }
        }

        public static System.Collections.Generic.IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            int skipped = 0;

            foreach (var item in source)
            {
                if (skipped >= count)
                    yield return item;
                else
                    skipped++;
            }
        }

        public static System.Collections.Generic.IEnumerable<T> SkipWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool skip = true;

            foreach (var item in source)
            {
                if (skip && !predicate(item))
                    skip = false;

                if (!skip)
                    yield return item;
            }
        }

        public static System.Collections.Generic.IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
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

        public static System.Collections.Generic.IEnumerable<T> TakeWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
                else
                    yield break;
            }
        }

        public static T First<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
            }

            throw new InvalidOperationException("No matching element found.");
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return item;
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

            if (found)
                return lastItem;
            else
                throw new InvalidOperationException("No matching element found.");
        }

        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            T lastItem = default(T);

            foreach (var item in source)
            {
                if (predicate(item))
                    lastItem = item;
            }

            return lastItem;
        }
    }

    public class LinkedList<T> : ILinkedList<T>
    {
        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }

            public Node(T item)
            {
                Item = item;
                Next = null;
            }
        }

        private Node first;
        private Node last;
        private int count;

        public LinkedList()
        {
            first = null;
            last = null;
            count = 0;
        }

        public void Add(T item)
        {
            Node newNode = new Node(item);

            if (count == 0)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }

            count++;
        }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (count == 0)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }

            count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(item);
            }
            else if (index == count)
            {
                Add(item);
            }
            else
            {
                Node newNode = new Node(item);
                Node previousNode = GetNodeAt(index - 1);
                Node nextNode = previousNode.Next;

                previousNode.Next = newNode;
                newNode.Next = nextNode;

                count++;
            }
        }

        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node currentNode = first;

            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                    return true;

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            Node currentNode = first;

            for (int i = 0; i < count; i++)
            {
                array[i] = currentNode.Item;
                currentNode = currentNode.Next;
            }

            return array;
        }

        public int Count => count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                Node node = GetNodeAt(index);
                return node.Item;
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                Node node = GetNodeAt(index);
                node.Item = value;
            }
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node currentNode = first;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = first;

            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        public void Sort()
        {
            T[] array = ToArray();
            Array.Sort(array);

            Clear();

            foreach (var item in array)
            {
                Add(item);
            }
        }

        public int BinarySearch(T item)
        {
            if (count == 0)
                return -1;

            int low = 0;
            int high = count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                T midItem = this[mid];

                if (midItem.Equals(item))
                    return mid;
                else if (Comparer<T>.Default.Compare(midItem, item) < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
    }
}
