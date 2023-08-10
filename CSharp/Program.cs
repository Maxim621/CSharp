using CSharp.Homework12;
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

            var cancelTask = Task.Run(() =>
            {
                while (true)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        tasksRunner.CancelTasks();
                        Console.WriteLine("Виконання завдань було скасовано.");
                        break;
                    }
                }
            });

            Console.WriteLine("Генерація випадкового масиву:");
            var randomArray = tasksRunner.GenerateRandomArray();
            tasksRunner.PrintArrayWithProgress(randomArray);

            Console.WriteLine("Генерація масиву з функцією f(i):");
            var functionArray = tasksRunner.GenerateArrayWithFunction(i => i * i);
            tasksRunner.PrintArrayWithProgress(functionArray);

            Console.WriteLine("Копіюємо частину масиву:");
            var copiedArray = tasksRunner.CopyArrayPart(randomArray, 0, arraySize / 2);
            tasksRunner.PrintArrayWithProgress(copiedArray);

            Console.WriteLine($"Мінімум: {tasksRunner.FindMin()}");
            Console.WriteLine($"Максимум: {tasksRunner.FindMax()}");
            Console.WriteLine($"Сума: {tasksRunner.FindSum()}");
            Console.WriteLine($"Середнє: {tasksRunner.FindAverage()}");

            Console.WriteLine("Введіть довгий книжковий текст або рядок для аналізу:");
            string text = Console.ReadLine();

            Console.WriteLine("Частотний словник символів:");
            var charFrequency = tasksRunner.CalculateCharacterFrequency(text);
            tasksRunner.PrintDictionaryWithProgress(charFrequency);

            Console.WriteLine("Частотний словник слів:");
            var wordFrequency = tasksRunner.CalculateWordFrequency(text);
            tasksRunner.PrintDictionaryWithProgress(wordFrequency);

            cancelTask.Wait();
        }
    }
}