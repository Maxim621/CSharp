using System;
using System.Linq;

namespace CSharp.Homework5.Stack
{
    public class RealizationStack
    {
        public static void Start()
        {
            GenericStack<int> stack = new GenericStack<int>();

            // Додавання елементів до стека
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // Використання методів розширення:

            // Filter - відсіває елементи, для яких предекат повертає false
            stack.Filter(x => x % 2 == 0);

            // Skip - пропускає перші два елементи
            stack.Skip(2);

            // Take - бере перші три елементи
            stack.Take(3);

            // Select - обчислює квадрат кожного елемента
            var squaredNumbers = stack.Select(x => x * x);

            // All - перевіряє, чи всі елементи задовольняють умову
            bool allEven = stack.All(x => x % 2 == 0);

            // Any - перевіряє, чи хоча б один елемент задовольняє умову
            bool hasOddNumber = stack.Any(x => x % 2 != 0);

            // ToArray - перетворює стек у масив
            int[] array = stack.ToArray();

            // ToList - перетворює стек у список
            var list = stack.ToList();

            // Виведення результатів
            Console.WriteLine("Filtered Stack:");
            foreach (var item in stack.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Squared Numbers:");
            foreach (var item in squaredNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("All numbers are even: " + allEven);
            Console.WriteLine("Has odd number: " + hasOddNumber);

            Console.WriteLine("Array:");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("List:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
