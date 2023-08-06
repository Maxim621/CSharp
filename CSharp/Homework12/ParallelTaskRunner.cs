using System;
using System.Threading.Tasks;

namespace CSharp.Homework12
{
    public static class ParallelTaskRunner<T>
    {
        public static T[] RunParallelTask(int numThreads, int arraySize, Func<int, T> taskFunction)
        {
            T[] resultArray = new T[arraySize];
            var options = new ParallelOptions { MaxDegreeOfParallelism = numThreads };
            Parallel.For(0, arraySize, options, i => resultArray[i] = taskFunction(i));
            return resultArray;
        }
    }
}
