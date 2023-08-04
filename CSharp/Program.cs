using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Виведіть усі числа від 10 до 50 через кому
        Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41)));

        // Виведіть лише ті числа від 10 до 50, які можна поділити на 3
        Console.WriteLine(string.Join(", ", Enumerable.Range(10, 41).Where(x => x % 3 == 0)));

        // Виведіть слово "Linq" 10 разів
        Console.WriteLine(string.Concat(Enumerable.Repeat("Linq ", 10)));

        // Вивести всі слова з буквою «а» в рядку «aaa;abb;ccc;dap»
        Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Where(s => s.Contains("a"))));

        // Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa;abb;ccc;dap» через кому
        Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';').Select(s => s.Count(c => c == 'a'))));

        // Вивести true, якщо слово "abb" існує в рядку "aaa;xabbx;abb;ccc;dap", інакше false
        Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Any(s => s == "abb"));

        // Отримати найдовше слово в рядку "aaa;xabbx;abb;ccc;dap"
        Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').MaxBy(s => s.Length));

        // Обчислити середню довжину слова в рядку "aaa;xabbx;abb;ccc;dap"
        Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Average(s => s.Length));

        // Вивести найкоротше слово в рядку "aaa;xabbx;abb;ccc;dap;zh" у зворотному порядку
        Console.WriteLine(new string("aaa;xabbx;abb;ccc;dap;zh".Split(';').MinBy(s => s.Length).Reverse().ToArray()));

        // Вивести true, якщо в першому слові, яке починається з "aa", усі літери "b" (За винятком "аа"), інакше false
        Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').FirstOrDefault(s => s.StartsWith("aa") && s.Skip(2).All(c => c == 'b')) != null);

        // Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на "bb" (використовуйте послідовність із 10 завдання)
        Console.WriteLine(string.Join(";", "aaa;xabbx;abb;ccc;dap".Split(';').Where(s => s.EndsWith("bb")).Skip(2).TakeLast(1)));

    }
}