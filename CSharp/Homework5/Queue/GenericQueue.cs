using System;

namespace CSharp.Homework5.Queue
{
    public class GenericQueue<T> : IQueue<T>
    {
        private T[] elements;
        private int head;
        private int tail;

        public GenericQueue()
        {
            elements = new T[16];
            head = 0;
            tail = -1;
        }

        public void Enqueue(T item)
        {
            if (tail == elements.Length - 1) // Перевірка на заповненість масиву
            {
                // Збільшуємо розмір масиву удвічі
                T[] newElements = new T[elements.Length * 2];

                // Копіюємо елементи зі старого масиву в новий
                for (int i = 0; i < elements.Length; i++)
                {
                    newElements[i] = elements[i];
                }

                elements = newElements;
            }

            tail++;
            elements[tail] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T item = elements[head];
            elements[head] = default(T); // Очищуємо посилання для відновлення пам'яті

            head++;

            // Перевірка на зміщення голови на початок масиву
            if (head > 0 && head == tail + 1)
            {
                // Зміщуємо елементи на початок масиву
                for (int i = head; i <= tail; i++)
                {
                    elements[i - head] = elements[i];
                    elements[i] = default(T);
                }

                tail -= head;
                head = 0;
            }

            return item;
        }

        public void Clear()
        {
            for (int i = head; i <= tail; i++)
            {
                elements[i] = default(T);
            }

            head = 0;
            tail = -1;
        }

        public bool Contains(T item)
        {
            for (int i = head; i <= tail; i++)
            {
                if (elements[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return elements[head];
        }

        public T[] ToArray()
        {
            T[] array = new T[tail - head + 1];

            for (int i = head; i <= tail; i++)
            {
                array[i - head] = elements[i];
            }

            return array;
        }

        public int Count => tail - head + 1;

        private bool IsEmpty()
        {
            return head > tail;
        }
    }
}