using Charp.Homework12;
using System;

namespace CSharp.Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть кількість потоків:");
            int numThreads = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть розмір масиву:");
            int arraySize = int.Parse(Console.ReadLine());

            var tasksRunner = new TasksRunner(numThreads, arraySize);

            // Генерація випадкового масиву
            Console.WriteLine("Генерація випадкового масиву:");
            var randomArray = tasksRunner.GenerateRandomArray();
            tasksRunner.PrintArray(randomArray);

            // Генерація масиву з функцією f(i)
            Console.WriteLine("Генерація масиву з функцією f(i):");
            var functionArray = tasksRunner.GenerateArrayWithFunction(i => i * i);
            tasksRunner.PrintArray(functionArray);

            // Копіюємо частину масиву
            Console.WriteLine("Копіюємо частину масиву:");
            var copiedArray = tasksRunner.CopyArrayPart(randomArray, 0, arraySize / 2);
            tasksRunner.PrintArray(copiedArray);

            // Знаходимо мінімум, максимум, суму та середнє значення в масиві
            Console.WriteLine($"Мінімум: {tasksRunner.FindMin()}");
            Console.WriteLine($"Максимум: {tasksRunner.FindMax()}");
            Console.WriteLine($"Сума: {tasksRunner.FindSum()}");
            Console.WriteLine($"Середнє: {tasksRunner.FindAverage()}");

            // Введення тексту для аналізу
            Console.WriteLine("Введіть довгий книжковий текст або рядок для аналізу:");
            string text = Console.ReadLine();

            // Частотний словник символів та слів у тексті
            Console.WriteLine("Частотний словник символів:");
            var charFrequency = tasksRunner.CalculateCharacterFrequency(text);
            tasksRunner.PrintDictionary(charFrequency);

            Console.WriteLine("Частотний словник слів:");
            var wordFrequency = tasksRunner.CalculateWordFrequency(text);
            tasksRunner.PrintDictionary(wordFrequency);
        }
    }
}