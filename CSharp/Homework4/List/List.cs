namespace CSharp.Homework4.List
{
    public class StartList
    {
        public static void Start()
        {
            List myList = new List();

            // Додавання елементів до списку
            myList.Add("Item 1");
            myList.Add("Item 2");
            myList.Add("Item 3");

            // Вставка елемента на певну позицію
            myList.Insert(1, "Inserted Item");

            // Перевірка кількості елементів у списку
            Console.WriteLine("Count: " + myList.Count); // Виведе: Count: 4

            // Перевірка наявності елемента в списку
            bool containsItem = myList.Contains("Item 2");
            Console.WriteLine("Contains Item 2: " + containsItem); // Виведе: Contains Item 2: True

            // Отримання індексу елемента в списку
            int index = myList.IndexOf("Item 3");
            Console.WriteLine("Index of Item 3: " + index); // Виведе: Index of Item 3: 2

            // Видалення елемента зі списку
            myList.Remove("Item 1");

            // Перевірка кількості елементів після видалення
            Console.WriteLine("Count: " + myList.Count); // Виведе: Count: 3

            // Перетворення списку в масив
            object[] array = myList.ToArray();

            // Зворотнє впорядкування списку
            myList.Reverse();

            // Очищення списку
            myList.Clear();
        }
    }
}
