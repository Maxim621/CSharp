using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Hoemwork12
{
    public static class ParallelTaskRunner<T>
    {
        public static T[] RunParallelTask(int numThreads, int arraySize, Func<int, T> taskFunction, CancellationToken cancellationToken)
        {
            T[] resultArray = new T[arraySize];

            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = numThreads,
                CancellationToken = cancellationToken
            };

            Parallel.For(0, arraySize, options, i =>
            {
                resultArray[i] = taskFunction(i);
            });

            return resultArray;
        }
    }
}