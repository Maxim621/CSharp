using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework4.DoublyLinked
{
    public class DoublyLinkedList
    {
        private class Node
        {
            public object Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(object value)
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

        public object First
        {
            get
            {
                if (first == null)
                    throw new InvalidOperationException("The list is empty.");
                return first.Value;
            }
        }

        public object Last
        {
            get
            {
                if (last == null)
                    throw new InvalidOperationException("The list is empty.");
                return last.Value;
            }
        }

        public void Add(object item)
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

        public void AddFirst(object item)
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

        public bool Contains(object item)
        {
            Node current = first;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public bool Remove(object item)
        {
            Node current = first;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    RemoveNode(current);
                    return true;
                }

                current = current.Next;
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

        public object[] ToArray()
        {
            object[] array = new object[count];
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
    }
}
