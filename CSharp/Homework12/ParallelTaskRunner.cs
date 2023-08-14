using System;
using System.Numerics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharp.Hoemwork12
{
    public abstract class ParallelTaskRunner<T>
    {
        protected readonly int numThreads;
        protected readonly Memory<T> array;

        public ParallelTaskRunner(int numThreads, Memory<T> array)
        {
            this.numThreads = numThreads;
            this.array = array;
        }

        public void RunParallelTask(CancellationToken cancellationToken)
        {
            var tasks = new Task[numThreads];
            var itemPerThread = array.Length / numThreads;

            for (int i = 0; i < numThreads && !cancellationToken.IsCancellationRequested; i++)
            {
                int threadNum = i;
                var taskArraySpan = threadNum == numThreads - 1
                    ? array[(threadNum * itemPerThread)..]
                    : array.Slice((threadNum * itemPerThread), itemPerThread);

                tasks[i] = RunTask(taskArraySpan, threadNum, itemPerThread, cancellationToken);
            }

            Task.WaitAll(tasks, cancellationToken);

            AfterRun();
        }

        protected virtual void AfterRun() { }

        private Task RunTask(Memory<T> taskArraySpan, int threadNum, int itemPerThread, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var span = taskArraySpan.Span;
                ProcessItems(span, threadNum, itemPerThread, cancellationToken);
            }, cancellationToken);
        }

        protected virtual void ProcessItems(Span<T> span, int threadNum, int itemPerThread, CancellationToken cancellationToken)
        {
            for (int index = 0; index < span.Length; index++)
            {
                if (!cancellationToken.IsCancellationRequested)
                    ProcessItem(span, index, index + (threadNum * itemPerThread));
            }
        }

        protected virtual T ProcessItem(Span<T> span, int index, int absoluteIndex) => span[index];
    }

    public class FuncParallelTaskRunner<T> : ParallelTaskRunner<T>
    {
        private readonly Func<int, T> _func;

        public FuncParallelTaskRunner(int numThreads, T[] array, Func<int, T> func)
            : base(numThreads, array)
        {
            this._func = func;
        }

        protected override T ProcessItem(Span<T> span, int index, int absoluteIndex)
        {
            return span[index] = _func(absoluteIndex);
        }
    }

    public class RandomParallelTaskRunner : ParallelTaskRunner<int>
    {
        private readonly Random _random = new Random();

        public RandomParallelTaskRunner(int numThreads, int[] array)
            : base(numThreads, array)
        {
        }

        protected override int ProcessItem(Span<int> span, int index, int absoluteIndex)
        {
            return span[index] = _random.Next();
        }
    }

    public abstract class ResultParallelTaskRunner<T, TResult> : ParallelTaskRunner<T>
    {
        protected readonly TResult[] _results;

        public TResult Result { get; protected set; } = default!;

        public ResultParallelTaskRunner(int numThreads, T[] array)
            : base(numThreads, array)
        {
            _results = new TResult[numThreads];
        }
    }

    public class SumParallelTaskRunner<T> : ResultParallelTaskRunner<T, decimal> where T : INumber<T>
    {
        public SumParallelTaskRunner(int numThreads, T[] array) : base(numThreads, array)
        {
        }

        protected override void AfterRun()
        {
            base.AfterRun();
            Result = 0;
            foreach (var item in _results)
            {
                Result += item;
            }
        }

        protected override void ProcessItems(Span<T> span, int threadNum, int itemPerThread, CancellationToken cancellationToken)
        {
            _results[threadNum] = 0;
            for (int index = 0; index < span.Length; index++)
            {
                if (!cancellationToken.IsCancellationRequested)
                    _results[threadNum] = decimal.CreateChecked(span[index]) + _results[threadNum];
            }
        }
    }

    public class AvgParallelTaskRunner<T> : SumParallelTaskRunner<T> where T : INumber<T>
    {
        public AvgParallelTaskRunner(int numThreads, T[] array) : base(numThreads, array)
        {
        }

        protected override void AfterRun()
        {
            base.AfterRun();
            Result /= array.Length;
        }
    }

    public abstract class MinMaxParallelTaskRunner<T> : ResultParallelTaskRunner<T, T> where T : INumber<T>
    {
        public MinMaxParallelTaskRunner(int numThreads, T[] array) : base(numThreads, array)
        {
        }

        protected override void AfterRun()
        {
            base.AfterRun();
            Result = _results.Min()!;
        }

        protected override void ProcessItems(Span<T> span, int threadNum, int itemPerThread, CancellationToken cancellationToken)
        {
            _results[threadNum] = span[0];
            for (int index = 0; index < span.Length; index++)
            {
                if (!cancellationToken.IsCancellationRequested)
                    if (Compare(_results[threadNum], span[index]))
                        _results[threadNum] = span[index];
            }
        }

        protected abstract bool Compare(T current, T other);
    }

    public class MinParallelTaskRunner<T> : MinMaxParallelTaskRunner<T> where T : INumber<T>
    {
        public MinParallelTaskRunner(int numThreads, T[] array) : base(numThreads, array)
        {
        }

        protected override bool Compare(T current, T other) => current > other;
    }

    public class MaxParallelTaskRunner<T> : MinMaxParallelTaskRunner<T> where T : INumber<T>
    {
        public MaxParallelTaskRunner(int numThreads, T[] array) : base(numThreads, array)
        {
        }

        protected override bool Compare(T current, T other) => current < other;
    }

    public class CopyParallelTaskRunner<T> : ParallelTaskRunner<T>
    {
        private readonly T[] _resultArray;

        public T[] Result => _resultArray;

        public CopyParallelTaskRunner(int numThreads, T[] array, int startIndex, int length)
            : base(numThreads, array.AsMemory(startIndex, length))
        {
            if (startIndex < 0 || startIndex >= array.Length) throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (length <= 0 || startIndex + length > array.Length) throw new ArgumentOutOfRangeException(nameof(length));

            _resultArray = new T[length];
        }

        protected override T ProcessItem(Span<T> span, int index, int absoluteIndex)
        {
            var item = span[index];
            _resultArray[absoluteIndex] = item;
            return item;
        }
    }

    public abstract class FrequencyParallelTaskRunner<T> : ResultParallelTaskRunner<string, Dictionary<T, int>> where T : notnull
    {
        protected FrequencyParallelTaskRunner(int numThreads, string[] array)
            : base(numThreads, array)
        {
        }

        protected abstract T[] ProcessItemForDictionary(string item);

        protected override void ProcessItems(Span<string> span, int threadNum, int itemPerThread, CancellationToken cancellationToken)
        {
            for (int index = 0; index < span.Length; index++)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    if (_results[threadNum] == null) _results[threadNum] = new Dictionary<T, int>();
                    var dic = _results[threadNum];
                    var result = ProcessItemForDictionary(ProcessItem(span, index, index + (threadNum * itemPerThread)));;
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (dic.ContainsKey(result[i]))
                            dic[result[i]]++;
                        else
                            dic[result[i]] = 1;
                    }
                }
            }
        }

        protected override void AfterRun()
        {
            base.AfterRun();
            Result ??= new Dictionary<T, int>();
            foreach (var item in _results)
            {
                foreach (var dicValue in item)
                {
                    if (Result.TryGetValue(dicValue.Key, out _))
                        Result[dicValue.Key] += dicValue.Value;
                    else
                        Result[dicValue.Key] = dicValue.Value;
                }
            }
        }
    }

    public class CharacterFrequencyParallelTaskRunner : FrequencyParallelTaskRunner<char>
    {
        public CharacterFrequencyParallelTaskRunner(int numThreads, string[] array)
            : base(numThreads, array)
        {
        }

        protected override char[] ProcessItemForDictionary(string item) => item.ToCharArray();
    }

    public class WordFrequencyParallelTaskRunner : FrequencyParallelTaskRunner<string>
    {
        public WordFrequencyParallelTaskRunner(int numThreads, string[] array)
            : base(numThreads, array)
        {
        }

        protected override string[] ProcessItemForDictionary(string item) => item.Split(new[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
    }
}