using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Homework5.PriorityQueue
{
    public class List<T> : IList<T>
    {
        private T[] items;
        private int count;
        private IEnumerable<T> source;

        public List()
        {
            const int defaultCapacity = 4;
            items = new T[defaultCapacity];
            count = 0;
        }

        public List(int capacity)
        {
            items = new T[capacity];
            count = 0;
        }

        public List(IEnumerable<T> source)
        {
            this.source = source;
        }

        public int Count => count;

        public void Add(T item)
        {
            if (count == items.Length)
                ResizeArray();

            items[count] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void Clear()
        {
            Array.Clear(items, 0, count);
            count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException();

                items[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (Equals(items[i], item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();

            if (count == items.Length)
                ResizeArray();

            Array.Copy(items, index, items, index + 1, count - index);
            items[index] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Array.Copy(items, index + 1, items, index, count - index - 1);
            count--;
        }

        private void ResizeArray()
        {
            int newCapacity = items.Length * 2;
            if (newCapacity == 0)
                newCapacity = 1;

            T[] newArray = new T[newCapacity];
            Array.Copy(items, newArray, count);
            items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
