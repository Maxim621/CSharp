using System;
using System.Collections.Generic;

namespace CSharp.Homework5.ObservableList
{
    public class RealizationObservable
    {
        public static void Start()
        {
            List<string> fruits = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };

            // Використовуємо метод розширення YieldFilter (Where) для фільтрації списку фруктів
            IEnumerable<string> filteredFruits = fruits.YieldFilter(fruit => fruit.Length > 5);

            // Виводимо відфільтровані фрукти
            foreach (string fruit in filteredFruits)
            {
                Console.WriteLine(fruit); // Виведе фрукти з довжиною назви більше 5 символів: banana, cherry, elderberry
            }
        }
    }
}
