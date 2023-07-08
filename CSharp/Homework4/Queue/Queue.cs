namespace CSharp.Homework4.QueueFolder
{
    public class StartQueue
    {
        public static void Start()
        {
            Queue queue = new Queue();

            // Додавання елементів до черги
            queue.Enqueue("Елемент 1");
            queue.Enqueue("Елемент 2");
            queue.Enqueue("Елемент 3");

            // Перевірка кількості елементів у черзі
            Console.WriteLine("Кількість елементів у черзі: " + queue.Count); // Виведе: 3

            // Перегляд першого елемента без видалення
            Console.WriteLine("Перший елемент: " + queue.Peek()); // Виведе: Елемент 1

            // Видалення та отримання елемента з черги
            object item1 = queue.Dequeue();
            Console.WriteLine("Видалений елемент: " + item1); // Виведе: Елемент 1

            // Перевірка наявності елемента у черзі
            Console.WriteLine("Чи містить черга 'Елемент 2': " + queue.Contains("Елемент 2")); // Виведе: True

            // Очищення черги
            queue.Clear();

            // Перевірка кількості елементів після очищення
            Console.WriteLine("Кількість елементів у черзі після очищення: " + queue.Count); // Виведе: 0
        }
    }
}
