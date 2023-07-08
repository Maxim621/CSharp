namespace CSharp.Homework4.BinarySearch
{
    public class BinarySearchTree
    {
        private class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private Node root;
        public int Count { get; private set; }

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
                Count = 1;
                return;
            }

            AddTo(root, value);
            Count++;
        }

        private void AddTo(Node node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                    node.Left = new Node(value);
                else
                    AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new Node(value);
                else
                    AddTo(node.Right, value);
            }
        }

        public bool Contains(int value)
        {
            return Contains(root, value);
        }

        private bool Contains(Node node, int value)
        {
            if (node == null)
                return false;

            if (value == node.Value)
                return true;

            if (value < node.Value)
                return Contains(node.Left, value);
            else
                return Contains(node.Right, value);
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;
            TraverseInOrder(root, ref array, ref index);
            return array;
        }

        private void TraverseInOrder(Node node, ref int[] array, ref int index)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, ref array, ref index);
                array[index++] = node.Value;
                TraverseInOrder(node.Right, ref array, ref index);
            }
        }

        public void Balance()
        {
            int[] sortedArray = ToArray();
            Clear();
            BalanceFromArray(sortedArray, 0, sortedArray.Length - 1);
        }

        private void BalanceFromArray(int[] sortedArray, int start, int end)
        {
            if (start > end)
                return;

            int mid = (start + end) / 2;
            Add(sortedArray[mid]);

            BalanceFromArray(sortedArray, start, mid - 1);
            BalanceFromArray(sortedArray, mid + 1, end);
        }
    }
}
