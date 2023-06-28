namespace CSharp.Homework4
{
    public class StartBinarySearchTree
    {
        public static void Start()
        {
            BinarySearchTree tree = new BinarySearchTree();

            // Додавання елементів до дерева
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(4);

            // Перевірка наявності елементів у дереві
            Console.WriteLine(tree.Contains(3));  // Виведе: True
            Console.WriteLine(tree.Contains(6));  // Виведе: False

            // Отримання масиву значень з дерева
            int[] array = tree.ToArray();
            Console.WriteLine(string.Join(", ", array));  // Виведе: 1, 3, 4, 5, 7

            // Очищення дерева
            tree.Clear();

            // Балансування дерева
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(4);
            tree.Balance();

            // Отримання масиву значень з збалансованого дерева
            int[] balancedArray = tree.ToArray();
            Console.WriteLine(string.Join(", ", balancedArray));  // Може вивести різні перестановки значень, наприклад: 1, 3, 4, 5, 7 або 3, 1, 5, 4, 7
        }
    }
}
