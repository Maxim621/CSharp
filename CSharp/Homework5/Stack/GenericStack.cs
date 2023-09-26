using System;

namespace CSharp.Homework5.Stack
{
    public class GenericStack<T> : IStack<T>
    {
        private T[] data;
        private int top;

        public GenericStack()
        {
            data = new T[100];
            top = -1;
        }

        public void Clear()
        {
            top = -1;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i <= top; i++)
            {
                if (data[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public T Peek()
        {
            if (top >= 0)
            {
                return data[top];
            }
            throw new InvalidOperationException("Stack is empty.");
        }

        public T[] ToArray()
        {
            T[] array = new T[top + 1];
            Array.Copy(data, array, top + 1);
            return array;
        }

        public void Push(T item)
        {
            if (top == data.Length - 1)
            {
                T[] newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            top++;
            data[top] = item;
        }

        public T Pop()
        {
            if (top >= 0)
            {
                T item = data[top];
                top--;
                return item;
            }
            throw new InvalidOperationException("Stack is empty.");
        }

        public int Count
        {
            get { return top + 1; }
        }
    }
}
