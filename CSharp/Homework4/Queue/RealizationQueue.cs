using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework4.QueueFolder
{
    public class Queue
    {
        private object[] elements;
        private int head;
        private int tail;

        public Queue()
        {
            elements = new object[16]; // Початковий розмір масиву
            head = 0;
            tail = -1;
        }

        public void Enqueue(object obj)
        {
            if (tail == elements.Length - 1) // Перевірка на заповненість масиву
            {
                // Збільшуємо розмір масиву удвічі
                object[] newElements = new object[elements.Length * 2];

                // Копіюємо елементи зі старого масиву в новий
                for (int i = 0; i < elements.Length; i++)
                {
                    newElements[i] = elements[i];
                }

                elements = newElements;
            }

            tail++;
            elements[tail] = obj;
        }

        public object Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            object obj = elements[head];
            elements[head] = null; // Очищуємо посилання для відновлення пам'яті

            head++;

            // Перевірка на зміщення голови на початок масиву
            if (head > 0 && head == tail + 1)
            {
                // Зміщуємо елементи на початок масиву
                for (int i = head; i <= tail; i++)
                {
                    elements[i - head] = elements[i];
                    elements[i] = null;
                }

                tail -= head;
                head = 0;
            }

            return obj;
        }

        public void Clear()
        {
            for (int i = head; i <= tail; i++)
            {
                elements[i] = null;
            }

            head = 0;
            tail = -1;
        }

        public bool Contains(object obj)
        {
            for (int i = head; i <= tail; i++)
            {
                if (elements[i].Equals(obj))
                {
                    return true;
                }
            }

            return false;
        }

        public object Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return elements[head];
        }

        public object[] ToArray()
        {
            object[] array = new object[tail - head + 1];

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
