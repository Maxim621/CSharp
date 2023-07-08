namespace CSharp.Homework4.DoublyLinked
{
    public class StartDoublyLinkedList
    {
        public static void Start()
        {
            RealizationDoublyLinkedList list = new RealizationDoublyLinkedList();

            list.Add("Apple");
            list.Add("Banana");
            list.Add("Orange");

            Console.WriteLine("Count: " + list.Count);
            Console.WriteLine("First: " + list.First);
            Console.WriteLine("Last: " + list.Last);
            Console.WriteLine("Contains 'Banana': " + list.Contains("Banana"));

            list.Remove("Banana");

            Console.WriteLine("Count after removal: " + list.Count);
            Console.WriteLine("First after removal: " + list.First);
            Console.WriteLine("Last after removal: " + list.Last);
            Console.WriteLine("Contains 'Banana' after removal: " + list.Contains("Banana"));

            object[] array = list.ToArray();
            Console.WriteLine("List as array:");
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }

            list.Clear();
            Console.WriteLine("Count after clearing: " + list.Count);
        }
    }
}
