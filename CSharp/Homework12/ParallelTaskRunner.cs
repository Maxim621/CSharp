using System;

namespace CSharp.Homework12
{
    public static class ParallelTaskRunner<T>
    {
        public static T[] RunParallelTask(int numThreads, int arraySize, Func<int, T> taskFunction)
        {
            T[] resultArray = new T[arraySize];
            var tasks = new Task[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                int index = i;
                tasks[i] = new Task(() => resultArray[index] = taskFunction(index));
            }

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks);

            return resultArray;
        }
    }
}