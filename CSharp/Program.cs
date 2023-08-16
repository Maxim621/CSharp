using CSharp.Homework14;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            Console.WriteLine("Введіть шлях до файлу з даними:");
            string filePath = Console.ReadLine();

            var lines = await ReadLinesAsync(filePath, cancellationToken);
            await ProcessCharacterFrequency(lines, numThreads, cancellationToken);
            await ProcessWordFrequency(lines, numThreads, cancellationToken);

            await cancelTask;
        }

        static async Task<string[]> ReadLinesAsync(string filePath, CancellationToken cancellationToken)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null && !cancellationToken.IsCancellationRequested)
                {
                    lines.Add(line);
                }
            }
            return lines.ToArray();
        }

        static async Task ProcessCharacterFrequency(string[] lines, int numThreads, CancellationToken cancellationToken)
        {
            var charFrequency = await Task.Run(() => TasksRunner.CalculateCharacterFrequency(numThreads, lines, cancellationToken));
            TasksRunner.PrintDictionary(charFrequency);
        }

        static async Task ProcessWordFrequency(string[] lines, int numThreads, CancellationToken cancellationToken)
        {
            var wordFrequency = await Task.Run(() => TasksRunner.CalculateWordFrequency(numThreads, lines, cancellationToken));
            TasksRunner.PrintDictionary(wordFrequency);
        }
    }
}