using CSharp.Homework12;
using System;
using System.Numerics;

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

            var cancel = new CancellationTokenSource();

            var cancelTask = Task.Run(() =>
            {
                while (!cancel.IsCancellationRequested)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        cancel.Cancel();
                        Console.WriteLine("Виконання завдань було скасовано.");
                        break;
                    }
                }
            }, cancel.Token);

            var array = new int[arraySize];

            Console.WriteLine("Генерація випадкового масиву:");
            var randomArray = TasksRunner.GenerateRandomArray(numThreads, array, cancel.Token);
            TasksRunner.PrintArray(randomArray);

            Console.WriteLine("Генерація масиву з функцією f(i):");
            var functionArray = TasksRunner.GenerateArrayWithFunction(numThreads, array, i => i * i, cancel.Token);
            TasksRunner.PrintArray(functionArray);

            Console.WriteLine("Копіюємо частину масиву:");
            var copiedArray = TasksRunner.CopyArrayPart(numThreads, randomArray, 0, arraySize / 2, cancel.Token);
            TasksRunner.PrintArray(copiedArray);

            Console.WriteLine($"Мінімум: {TasksRunner.FindMin(numThreads, functionArray, cancel.Token)}");
            Console.WriteLine($"Максимум: {TasksRunner.FindMax(numThreads, functionArray, cancel.Token)}");
            Console.WriteLine($"Сума: {TasksRunner.FindSum(numThreads, functionArray, cancel.Token)}");
            Console.WriteLine($"Середнє: {TasksRunner.FindAverage(numThreads, functionArray, cancel.Token)}");

            Console.WriteLine("Введіть довгий книжковий текст або рядок для аналізу:");
            string[] text = File.ReadAllLines("cities.txt");

            Console.WriteLine("Частотний словник символів:");
            var charFrequency = TasksRunner.CalculateCharacterFrequency(numThreads, text, cancel.Token);
            TasksRunner.PrintDictionary(charFrequency);

            Console.WriteLine("Частотний словник слів:");
            var wordFrequency = TasksRunner.CalculateWordFrequency(numThreads, text, cancel.Token);
            TasksRunner.PrintDictionary(wordFrequency);

            cancelTask.Wait();
        }
    }
}