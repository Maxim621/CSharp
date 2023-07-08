namespace CSharp.Homework4.Linked
{
    public class StartLinkedList
    {
        public static void Start()
        {
            RealizationLinkedList list = new RealizationLinkedList();

            list.Add("Елемент 1");
            list.Add("Елемент 2");
            list.AddFirst("Елемент 0");
            list.Insert(2, "Елемент 1.5");

            Console.WriteLine("Кількість елементів у списку: " + list.Count);
            Console.WriteLine("Перший елемент: " + list.First);
            Console.WriteLine("Останній елемент: " + list.Last);

            Console.WriteLine("Елементи у списку:");
            object[] array = list.ToArray();
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Чи міститься 'Елемент 2' у списку? " + list.Contains("Елемент 2"));

            list.Clear();
            Console.WriteLine("Кількість елементів у списку після очищення: " + list.Count);
        }
    }
}
