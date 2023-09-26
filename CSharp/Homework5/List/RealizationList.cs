using System;
using System.Collections.Generic;

namespace CSharp.Homework5.List
{
    public class RealizationList
    {
        public static void Start()
        {
            // Створимо колекцію на базі нашого List<T>
            List<int> myList = new List<int>();

            // Додамо елементи до колекції
            myList.Add(5);
            myList.Add(10);
            myList.Add(15);
            myList.Add(20);

            // Використовуємо індексатор для доступу до елементів колекції
            int firstElement = myList[0];
            Console.WriteLine("Перший елемент: " + firstElement); // Виведе: Перший елемент: 5

            // Видалення елементу зі списку
            myList.Remove(10);

            // Використовуємо методи Linq-подібних розширень
            var filteredList = myList.Filter(x => x > 10);
            var skippedList = myList.Skip(1);
            var takenList = myList.Take(2);
            var selectedList = myList.Select(x => x * 2);

            Console.WriteLine("Відфільтрований список:");
            foreach (var item in filteredList)
            {
                Console.WriteLine(item);
            }
            // Виведе: 15, 20

            Console.WriteLine("Пропущені елементи:");
            foreach (var item in skippedList)
            {
                Console.WriteLine(item);
            }
            // Виведе: 15, 20

            Console.WriteLine("Перші два елементи:");
            foreach (var item in takenList)
            {
                Console.WriteLine(item);
            }
            // Виведе: 5, 15

            Console.WriteLine("Вибраний список, де кожен елемент подвоєний:");
            foreach (var item in selectedList)
            {
                Console.WriteLine(item);
            }
            // Виведе: 10, 30, 40

            // Сортування та бінарний пошук
            myList.Sort();
            Console.WriteLine("Сортований список:");
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            // Виведе: 5, 15, 20

            int index = myList.BinarySearch(15);
            Console.WriteLine("Індекс елемента 15: " + index); // Виведе: Індекс елемента 15: 1
        }
    }
}
