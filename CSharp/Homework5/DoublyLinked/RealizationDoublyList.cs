using System;

namespace CSharp.Homework5.DoublyLinked
{
    public class StartDoublyList
    {
        public static void Start()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.Add(10);
            list.Add(20);
            list.Add(30);

            // Додавання елементів
            list.AddFirst(5);

            // Виведення кількості та значень першого та останнього елементів
            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("First: " + list.First);
            Console.WriteLine("Last: " + list.Last);

            // Перетворення списку в масив та виведення на консоль
            int[] array = list.ToArray();
            Console.WriteLine("List as array:");
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }

            // Видалення елементу
            list.Remove(20);

            // Перевірка наявності елемента
            Console.WriteLine("Contains 20: " + list.Contains(20));

            // Виведення кількості та значень першого та останнього елементів після видалення
            Console.WriteLine("Count after removal: " + list.Count);
            Console.WriteLine("First after removal: " + list.First);
            Console.WriteLine("Last after removal: " + list.Last);

            // Очищення списку
            list.Clear();

            // Виведення кількості елементів після очищення
            Console.WriteLine("Count after clearing: " + list.Count);
        }
    }
}
