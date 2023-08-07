using CSharp.Homework12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Charp.Homework12
{
    public class TasksRunner
    {
        private int numThreads;
        private int arraySize;
        private int[] array;

        public TasksRunner(int numThreads, int arraySize)
        {
            this.numThreads = numThreads;
            this.arraySize = arraySize;
        }

        public int[] GenerateRandomArray()
        {
            var random = new Random();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, _ => random.Next(1, 100));
        }

        public int[] GenerateArrayWithFunction(Func<int, int> function)
        {
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, function);
        }

        public int[] CopyArrayPart(int[] sourceArray, int startIndex, int length)
        {
            int[] copiedArray = new int[length];
            Parallel.For(0, length, new ParallelOptions { MaxDegreeOfParallelism = numThreads }, i => copiedArray[i] = sourceArray[startIndex + i]);
            return copiedArray;
        }

        public int FindMin()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i]).Min();
        }

        public int FindMax()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i]).Max();
        }

        public int FindSum()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i]).Sum();
        }

        public double FindAverage()
        {
            array = GenerateRandomArray();
            return ParallelTaskRunner<int>.RunParallelTask(numThreads, arraySize, i => array[i]).Average();
        }

        public Dictionary<char, int> CalculateCharacterFrequency(string text)
        {
            var charFrequency = new Dictionary<char, int>();

            Parallel.ForEach(text, c =>
            {
                lock (charFrequency)
                {
                    if (charFrequency.ContainsKey(c))
                        charFrequency[c]++;
                    else
                        charFrequency[c] = 1;
                }
            });

            return charFrequency;
        }

        public Dictionary<string, int> CalculateWordFrequency(string text)
        {
            var words = text.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var wordFrequency = new Dictionary<string, int>();

            Parallel.ForEach(words, word =>
            {
                lock (wordFrequency)
                {
                    if (wordFrequency.ContainsKey(word))
                        wordFrequency[word]++;
                    else
                        wordFrequency[word] = 1;
                }
            });

            return wordFrequency;
        }

        public void PrintArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        public void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}