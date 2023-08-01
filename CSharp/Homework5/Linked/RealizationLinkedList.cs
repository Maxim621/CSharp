using System;

namespace CSharp.Homework5.Linked
{
    public class StartLinkedList
    {
        private static System.Collections.Generic.IEnumerable<int> sortedList;

        public static void Start()
        {
            // Створюємо екземпляр LinkedList з типом int
            LinkedList<int> list = new LinkedList<int>();

            // Додаємо елементи до списку
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.AddFirst(5);

            // Виводимо кількість елементів у списку
            Console.WriteLine("Кількість елементів у списку: " + list.Count);

            // Виводимо всі елементи списку
            Console.WriteLine("Елементи у списку:");
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            // Використовуємо методи розширення Linq для фільтрації та сортування
            var filteredList = list.Filter(x => x > 10);
            //var sortedList = list.OrderBy(x => x);

            // Виводимо відфільтрований та відсортований список
            Console.WriteLine("Відфільтрований список:");
            //foreach (int item in filteredList)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("Відсортований список:");
            foreach (int item in sortedList)
            {
                Console.WriteLine(item);
            }

            // Використовуємо метод сортування в самому списку
            list.Sort();

            // Виводимо відсортований список після використання методу Sort
            Console.WriteLine("Відсортований список після використання методу Sort:");
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            // Використовуємо метод бінарного пошуку
            int searchValue = 20;
            int index = list.BinarySearch(searchValue);

            if (index >= 0)
            {
                Console.WriteLine($"Значення {searchValue} знайдено на позиції {index}");
            }
            else
            {
                Console.WriteLine($"Значення {searchValue} не знайдено у списку");
            }

            // Очищуємо список
            list.Clear();

            // Перевіряємо кількість елементів у списку після очищення
            Console.WriteLine("Кількість елементів у списку після очищення: " + list.Count);
        }
    }
}
