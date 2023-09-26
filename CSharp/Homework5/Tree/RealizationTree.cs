using System;
using System.Collections.Generic;

namespace CSharp.Homework5.Tree
{
    public class RealizationTree
    {
        public static void Start()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(4);

            // Приклад використання методу розширення Filter
            IEnumerable<int> filteredItems = tree.ToArray().Filter(item => item % 2 == 0);
            Console.WriteLine("Filtered items: " + string.Join(", ", filteredItems)); // Виведе: Filtered items: 4

            // Інші приклади використання методів розширень
            int firstEven = tree.ToArray().First(item => item % 2 == 0);
            Console.WriteLine("First even item: " + firstEven); // Виведе: First even item: 4

            int lastEven = tree.ToArray().Last(item => item % 2 == 0);
            Console.WriteLine("Last even item: " + lastEven); // Виведе: Last even item: 4

            // Збалансуємо дерево
            tree.Balance();
            Console.WriteLine("Balanced tree: " + string.Join(", ", tree.ToArray())); // Виведе: Balanced tree: 1, 3, 4, 5, 7

            // Зупинка консолі для перегляду результатів
            Console.ReadLine();
        }
    }
}
