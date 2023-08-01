using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Homework5.PriorityQueue
{
    public class RealizatsionPriorityQ
    {
        public static void Start()
        {
            List<int> numbers = new List<int> { 5, 15, 8, 25, 12, 3 };

            // Використовуємо розширення Filter
            IEnumerable<int> result = MyLinqExtensions.Filter(numbers, x => x > 10);

            foreach (int num in result)
            {
                Console.WriteLine(num); // Виведе 15, 25, 12
            }
        }
    }
}
