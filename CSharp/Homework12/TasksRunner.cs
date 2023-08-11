using CSharp.Hoemwork12;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CSharp.Hoemwork12
{
    public class TasksRunner
    {
        private int numThreads;
        private int arraySize;
        private int[] array;
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;

        public TasksRunner(int numThreads, int arraySize)
        {
            this.numThreads = numThreads;
            this.arraySize = arraySize;

            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        public int[] GenerateRandomArray()
        {
            var random = new Random();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, _ => random.Next(1, 100), cancellationToken);
        }

        public int[] GenerateArrayWithFunction(Func<int, int> function)
        {
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, function, cancellationToken);
        }

        public int[] CopyArrayPart(int[] sourceArray, int startIndex, int length)
        {
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, length, i => sourceArray[startIndex + i], cancellationToken);
        }

        public int FindMin()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i], cancellationToken).Min();
        }

        public int FindMax()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i], cancellationToken).Max();
        }

        public int FindSum()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i], cancellationToken).Sum();
        }

        public double FindAverage()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i], cancellationToken).Average();
        }

        public Dictionary<char, int> CalculateCharacterFrequency(string text)
        {
            ConcurrentDictionary<char, int> charFrequency = new ConcurrentDictionary<char, int>();

            Parallel.ForEach(text, c =>
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    charFrequency.AddOrUpdate(c, 1, (_, oldValue) => oldValue + 1);
                }
            });

            return charFrequency.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public Dictionary<string, int> CalculateWordFrequency(string text)
        {
            string[] words = text.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            ConcurrentDictionary<string, int> wordFrequency = new ConcurrentDictionary<string, int>();

            Parallel.ForEach(words, word =>
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    wordFrequency.AddOrUpdate(word, 1, (_, oldValue) => oldValue + 1);
                }
            });

            return wordFrequency.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        public void PrintArrayWithProgress(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId}: Елемент {i + 1}/{array.Length} - {array[i]}");
            }
        }

        public void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public void PrintDictionaryWithProgress<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            int count = 0;
            foreach (var item in dictionary)
            {
                count++;
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId}: Елемент {count}/{dictionary.Count} - {item.Key}: {item.Value}");
            }
        }

        public void CancelTasks()
        {
            cancellationTokenSource.Cancel();
        }
    }
}