using CSharp.Homework14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Homework14
{
    public static class TasksRunner
    {
        public static int[] GenerateRandomArray(int numThreads, int[] array, CancellationToken cancellationToken = default)
        {
            new RandomParallelTaskRunner(numThreads, array).RunParallelTask(cancellationToken);
            return array;
        }

        public static T[] GenerateArrayWithFunction<T>(int numThreads, T[] array, Func<int, T> function, CancellationToken cancellationToken = default)
        {
            new FuncParallelTaskRunner<T>(numThreads, array, function).RunParallelTask(cancellationToken);
            return array;
        }

        public static T[] CopyArrayPart<T>(int numThreads, T[] sourceArray, int startIndex, int length, CancellationToken cancellationToken = default)
        {
            var runner = new CopyParallelTaskRunner<T>(numThreads, sourceArray, startIndex, length);
            runner.RunParallelTask(cancellationToken);

            return runner.Result;
        }

        public static T FindMin<T>(int numThreads, T[] array, CancellationToken cancellationToken = default) where T : INumber<T>
        {
            var runner = new MinParallelTaskRunner<T>(numThreads, array);
            runner.RunParallelTask(cancellationToken);

            return runner.Result;
        }

        public static T FindMax<T>(int numThreads, T[] array, CancellationToken cancellationToken = default) where T : INumber<T>
        {
            var runner = new MaxParallelTaskRunner<T>(numThreads, array);
            runner.RunParallelTask(cancellationToken);

            return runner.Result;
        }

        public static decimal FindSum<T>(int numThreads, T[] array, CancellationToken cancellationToken = default) where T : INumber<T>
        {
            var runner = new SumParallelTaskRunner<T>(numThreads, array);
            runner.RunParallelTask(cancellationToken);

            return runner.Result;
        }

        public static decimal FindAverage<T>(int numThreads, T[] array, CancellationToken cancellationToken = default) where T : INumber<T>
        {
            var runner = new AvgParallelTaskRunner<T>(numThreads, array);
            runner.RunParallelTask(cancellationToken);

            return runner.Result;
        }

        public static Dictionary<char, int> CalculateCharacterFrequency(int numThreads, string[] lines, CancellationToken cancellationToken = default)
        {
            var runner = new CharacterFrequencyParallelTaskRunner(numThreads, lines);
            runner.RunParallelTask(cancellationToken);

            return runner.Result;
        }

        public static Dictionary<string, int> CalculateWordFrequency(int numThreads, string[] lines, CancellationToken cancellationToken = default)
        {
            var runner = new WordFrequencyParallelTaskRunner(numThreads, lines);
            runner.RunParallelTask(cancellationToken);
            return runner.Result;
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Елемент {i + 1}/{array.Length} - {array[i]}");
            }
        }

        public static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            int count = 0;
            foreach (var item in dictionary)
            {
                count++;
                Console.WriteLine($"Елемент {count}/{dictionary.Count} - {item.Key}: {item.Value}");
            }
        }
    }
}