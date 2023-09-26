using System;
using System.Collections.Generic;

namespace CSharp.Homework5.Tree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Left;
            public Node Right;

            public Node(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node root;
        public int Count { get; private set; }

        public void Add(T value)
        {
            root = AddTo(root, value);
            Count++;
        }

        private Node AddTo(Node node, T value)
        {
            if (node == null)
                return new Node(value);

            if (value.CompareTo(node.Value) < 0)
                node.Left = AddTo(node.Left, value);
            else
                node.Right = AddTo(node.Right, value);

            return node;
        }

        public bool Contains(T value)
        {
            return Contains(root, value);
        }

        private bool Contains(Node node, T value)
        {
            if (node == null)
                return false;

            if (value.CompareTo(node.Value) == 0)
                return true;

            if (value.CompareTo(node.Value) < 0)
                return Contains(node.Left, value);
            else
                return Contains(node.Right, value);
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            TraverseInOrder(root, array, ref index);
            return array;
        }

        private void TraverseInOrder(Node node, T[] array, ref int index)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, array, ref index);

                if (index < array.Length)
                {
                    array[index++] = node.Value;
                }
                else
                {
                    return;
                }

                TraverseInOrder(node.Right, array, ref index);
            }
        }

        public void Balance()
        {
            T[] sortedArray = ToArray();
            Clear();
            root = BuildBalancedTree(sortedArray, 0, sortedArray.Length - 1);
        }

        private Node BuildBalancedTree(T[] sortedArray, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            Node node = new Node(sortedArray[mid]);

            node.Left = BuildBalancedTree(sortedArray, start, mid - 1);
            node.Right = BuildBalancedTree(sortedArray, mid + 1, end);

            return node;
        }

        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        private int GetBalanceFactor(Node node)
        {
            if (node == null)
                return 0;

            return GetHeight(node.Left) - GetHeight(node.Right);
        }
    }
}
