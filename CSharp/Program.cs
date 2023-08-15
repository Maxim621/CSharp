using CSharp.Homework14;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Homework14
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введіть кількість потоків:");
            int numThreads = int.Parse(Console.ReadLine());

            Console.WriteLine("Введіть розмір масиву:");
            int arraySize = int.Parse(Console.ReadLine());

            var cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            var cancelTask = Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        cancellationTokenSource.Cancel();
                        Console.WriteLine("Виконання завдань було скасовано.");
                        break;
                    }
                }
            }, cancellationToken);

            int[] array = new int[arraySize];

            Console.WriteLine("Генерація випадкового масиву:");
            var randomArray = await Task.Run(() => TasksRunner.GenerateRandomArray(numThreads, array, cancellationToken));
            TasksRunner.PrintArray(randomArray);

            Console.WriteLine("Генерація масиву з функцією f(i):");
            var functionArray = await Task.Run(() => TasksRunner.GenerateArrayWithFunction(numThreads, array, i => i * i, cancellationToken));
            TasksRunner.PrintArray(functionArray);

            Console.WriteLine("Копіюємо частину масиву:");
            var copiedArray = await Task.Run(() => TasksRunner.CopyArrayPart(numThreads, randomArray, 0, arraySize / 2, cancellationToken));
            TasksRunner.PrintArray(copiedArray);

            Console.WriteLine($"Мінімум: {await Task.Run(() => TasksRunner.FindMin(numThreads, functionArray, cancellationToken))}");
            Console.WriteLine($"Максимум: {await Task.Run(() => TasksRunner.FindMax(numThreads, functionArray, cancellationToken))}");
            Console.WriteLine($"Сума: {await Task.Run(() => TasksRunner.FindSum(numThreads, functionArray, cancellationToken))}");
            Console.WriteLine($"Середнє: {await Task.Run(() => TasksRunner.FindAverage(numThreads, functionArray, cancellationToken))}");

            Console.WriteLine("Введіть довгий книжковий текст або рядок для аналізу:");
            string[] text = File.ReadAllLines("cities.txt");

            Console.WriteLine("Частотний словник символів:");
            var charFrequency = await Task.Run(() => TasksRunner.CalculateCharacterFrequency(numThreads, text, cancellationToken));
            TasksRunner.PrintDictionary(charFrequency);

            Console.WriteLine("Частотний словник слів:");
            var wordFrequency = await Task.Run(() => TasksRunner.CalculateWordFrequency(numThreads, text, cancellationToken));
            TasksRunner.PrintDictionary(wordFrequency);

            await cancelTask;
        }
    }
}