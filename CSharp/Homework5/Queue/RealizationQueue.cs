using System;
using System.Collections.Generic;

namespace CSharp.Homework5.Queue
{
    public class RealizationQueue
    {
        public static void Start()
        {
            // Використання GenericQueue з типом int
            IQueue<int> queue = new GenericQueue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Вивід елементів черги
            Console.WriteLine("Елементи черги:");
            foreach (var item in queue.ToArray())
            {
                Console.WriteLine(item);
            }

            // Використання методів розширення для IEnumerable<int>
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Використання методу розширення Filter (where)
            IEnumerable<int> filteredNumbers = numbers.Filter(x => x % 2 == 0);
            Console.WriteLine("Фільтровані числа:");
            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }

            // Використання методу розширення Skip
            IEnumerable<int> skippedNumbers = numbers.Skip(3);
            Console.WriteLine("Числа зі списку, пропущено 3 елементи:");
            foreach (var number in skippedNumbers)
            {
                Console.WriteLine(number);
            }

            // Використання методу розширення Take
            IEnumerable<int> takenNumbers = numbers.Take(5);
            Console.WriteLine("Перші 5 чисел із списку:");
            foreach (var number in takenNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
