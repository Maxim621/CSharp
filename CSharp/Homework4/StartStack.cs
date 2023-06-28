namespace CSharp.Homework4
{
    public class StartStack
    {
        public static void Start()
        {
            Stack stack = new Stack();

            // Додавання елементів до стека
            stack.Push("Елемент 1");
            stack.Push("Елемент 2");
            stack.Push("Елемент 3");

            // Отримання кількості елементів у стеці
            int count = stack.Count;
            Console.WriteLine("Кількість елементів у стеці: " + count);

            // Перевірка наявності елемента у стеці
            bool contains = stack.Contains("Елемент 2");
            Console.WriteLine("Елемент 2 знаходиться у стеці: " + contains);

            // Отримання значення з вершини стека без його видалення
            object topItem = stack.Peek();
            Console.WriteLine("Значення з вершини стека: " + topItem);

            // Видалення елемента з вершини стека
            object poppedItem = stack.Pop();
            Console.WriteLine("Видалений елемент: " + poppedItem);

            // Отримання масиву з елементами стека
            object[] stackArray = stack.ToArray();
            Console.WriteLine("Елементи стека:");
            foreach (object item in stackArray)
            {
                Console.WriteLine(item);
            }

            // Очищення стека
            stack.Clear();
            count = stack.Count;
            Console.WriteLine("Кількість елементів у стеці після очищення: " + count);

            Console.ReadLine();
        }
    }
}
