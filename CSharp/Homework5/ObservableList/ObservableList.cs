using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Homework5.ObservableList
{
    public class ObservableList<T> : IList<T>, ICollection<T>
    {
        private List<T> internalList = new List<T>();

        public event EventHandler CollectionChanged;

        public int Count => internalList.Count;

        public bool IsReadOnly => ((ICollection<T>)internalList).IsReadOnly;

        public T this[int index]
        {
            get => internalList[index];
            set
            {
                internalList[index] = value;
                OnCollectionChanged();
            }
        }

        public void Add(T item)
        {
            internalList.Add(item);
            OnCollectionChanged();
        }

        public void Clear()
        {
            internalList.Clear();
            OnCollectionChanged();
        }

        public bool Contains(T item)
        {
            return internalList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            internalList.Insert(index, item);
            OnCollectionChanged();
        }

        public bool Remove(T item)
        {
            bool result = internalList.Remove(item);
            if (result)
            {
                OnCollectionChanged();
            }
            return result;
        }

        public void RemoveAt(int index)
        {
            internalList.RemoveAt(index);
            OnCollectionChanged();
        }

        public void Sort()
        {
            internalList.Sort();
            OnCollectionChanged();
        }

        protected virtual void OnCollectionChanged()
        {
            CollectionChanged?.Invoke(this, EventArgs.Empty);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
