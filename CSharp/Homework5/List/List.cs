using System;
using System.Collections.Generic;

namespace CSharp.Homework5.List
{
    public class List<T> : IList<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public List()
        {
            capacity = 4; // Початкова ємність
            items = new T[capacity];
        }

        public List(int capacity)
        {
            this.capacity = capacity;
            items = new T[capacity];
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return items[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < count)
                {
                    items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Add(T item)
        {
            if (count == capacity)
            {
                ResizeArray();
            }

            items[count] = item;
            count++;
        }

        public void Insert(int index, T item)
        {
            if (index >= 0 && index <= count)
            {
                if (count == capacity)
                {
                    ResizeArray();
                }

                for (int i = count; i > index; i--)
                {
                    items[i] = items[i - 1];
                }

                items[index] = item;
                count++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < count)
            {
                for (int i = index; i < count - 1; i++)
                {
                    items[i] = items[i + 1];
                }

                count--;
                items[count] = default(T);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            Array.Clear(items, 0, count);
            count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, count);
        }

        private void ResizeArray()
        {
            capacity *= 2;
            T[] newArray = new T[capacity];
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

        public void Sort()
        {
            Array.Sort(items, 0, count);
        }

        public void Sort(Comparison<T> comparison)
        {
            Array.Sort(items, 0, count, Comparer<T>.Create(comparison));
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(items, 0, count, comparer);
        }

        public int BinarySearch(T item)
        {
            return Array.BinarySearch(items, 0, count, item);
        }

        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return Array.BinarySearch(items, 0, count, item, comparer);
        }

    }
}
