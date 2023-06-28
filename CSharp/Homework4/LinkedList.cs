using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework4
{
    public class LinkedList
    {
        private object[] elements;
        private int count;
        private int firstIndex;
        private int lastIndex;

        public LinkedList()
        {
            elements = new object[4];
            count = 0;
            firstIndex = -1;
            lastIndex = -1;
        }

        public void Add(object item)
        {
            if (count == elements.Length)
                ResizeArray();

            int newIndex = (lastIndex + 1) % elements.Length;
            elements[newIndex] = item;

            if (count == 0)
                firstIndex = newIndex;

            lastIndex = newIndex;
            count++;
        }

        public void AddFirst(object item)
        {
            if (count == elements.Length)
                ResizeArray();

            int newIndex = (firstIndex - 1 + elements.Length) % elements.Length;
            elements[newIndex] = item;

            if (count == 0)
                lastIndex = newIndex;

            firstIndex = newIndex;
            count++;
        }

        public void Insert(int index, object item)
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
                if (count == elements.Length)
                    ResizeArray();

                int currentIndex = (firstIndex + index) % elements.Length;
                int nextIndex = (currentIndex + 1) % elements.Length;

                // Shift elements to make room for the new item
                for (int i = lastIndex; i >= nextIndex; i = (i - 1 + elements.Length) % elements.Length)
                {
                    int prevIndex = (i - 1 + elements.Length) % elements.Length;
                    elements[i] = elements[prevIndex];
                }

                elements[nextIndex] = item;
                lastIndex = (lastIndex + 1) % elements.Length;
                count++;
            }
        }

        public void Clear()
        {
            elements = new object[4];
            count = 0;
            firstIndex = -1;
            lastIndex = -1;
        }

        public bool Contains(object item)
        {
            int index = firstIndex;
            for (int i = 0; i < count; i++)
            {
                if (elements[index].Equals(item))
                    return true;

                index = (index + 1) % elements.Length;
            }

            return false;
        }

        public object[] ToArray()
        {
            object[] array = new object[count];
            int index = firstIndex;

            for (int i = 0; i < count; i++)
            {
                array[i] = elements[index];
                index = (index + 1) % elements.Length;
            }

            return array;
        }

        public int Count => count;

        public object First => count > 0 ? elements[firstIndex] : null;

        public object Last => count > 0 ? elements[lastIndex] : null;

        private void ResizeArray()
        {
            object[] newArray = new object[elements.Length * 2];
            int index = firstIndex;

            for (int i = 0; i < count; i++)
            {
                newArray[i] = elements[index];
                index = (index + 1) % elements.Length;
            }

            elements = newArray;
            firstIndex = 0;
            lastIndex = count - 1;
        }
    }
}
