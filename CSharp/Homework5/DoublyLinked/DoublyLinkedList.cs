using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Homework5.DoublyLinked
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        private Node first;
        private Node last;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public T First
        {
            get { return first != null ? first.Value : throw new InvalidOperationException("The list is empty."); }
        }

        public T Last
        {
            get { return last != null ? last.Value : throw new InvalidOperationException("The list is empty."); }
        }

        public void Add(T item)
        {
            Node newNode = new Node(item);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                newNode.Previous = last;
                last = newNode;
            }

            count++;
        }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                newNode.Next = first;
                first.Previous = newNode;
                first = newNode;
            }

            count++;
        }

        public bool Contains(T item)
        {
            Node node = FindNode(item);
            return node != null;
        }

        public bool Remove(T item)
        {
            Node node = FindNode(item);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (first == null)
                throw new InvalidOperationException("The list is empty.");

            RemoveNode(first);
        }

        public void RemoveLast()
        {
            if (last == null)
                throw new InvalidOperationException("The list is empty.");

            RemoveNode(last);
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            Node current = first;

            for (int i = 0; i < count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Clear()
        {
            first = null;
            last = null;
            count = 0;
        }

        private Node FindNode(T item)
        {
            Node current = first;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                    return current;

                current = current.Next;
            }

            return null;
        }

        private void RemoveNode(Node node)
        {
            if (node == first)
            {
                first = node.Next;
                if (first != null)
                    first.Previous = null;
            }
            else if (node == last)
            {
                last = node.Previous;
                if (last != null)
                    last.Next = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
            }

            count--;
        }

        // ICollection<T> implementation...

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsReadOnly => false;

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < count)
                throw new ArgumentException("The number of elements in the source list is greater than the available space from arrayIndex to the end of the destination array.");

            Node current = first;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }
    }
}
