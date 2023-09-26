using System;
using System.Collections.Generic;

namespace CSharp.Homework5.Stack
{
    public static class StackExtensions
    {
        public static void Filter<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                if (predicate(item))
                {
                    tempStack.Push(item);
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }

        public static void Skip<T>(this IStack<T> stack, int count)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");
            }

            while (count > 0 && stack.Count > 0)
            {
                stack.Pop();
                count--;
            }
        }

        public static void SkipWhile<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0 && predicate(stack.Peek()))
            {
                stack.Pop();
            }
        }

        public static void Take<T>(this IStack<T> stack, int count)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");
            }

            IStack<T> tempStack = new GenericStack<T>();

            while (count > 0 && stack.Count > 0)
            {
                tempStack.Push(stack.Pop());
                count--;
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }

        public static void TakeWhile<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0 && predicate(stack.Peek()))
            {
                tempStack.Push(stack.Pop());
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }

        public static T First<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();
            T result = default;

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                if (predicate(item))
                {
                    result = item;
                    break;
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            if (result == null)
            {
                throw new InvalidOperationException("Element not found.");
            }

            return result;
        }

        public static T FirstOrDefault<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();
            T result = default;

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                if (predicate(item))
                {
                    result = item;
                    break;
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result;
        }

        public static T Last<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();
            T result = default;

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                if (predicate(item))
                {
                    result = item;
                }
                else
                {
                    tempStack.Push(item);
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            if (result == null)
            {
                throw new InvalidOperationException("Element not found.");
            }

            return result;
        }

        public static T LastOrDefault<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();
            T result = default;

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                if (predicate(item))
                {
                    result = item;
                }
                else
                {
                    tempStack.Push(item);
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result;
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IStack<T> stack, Func<T, TResult> selector)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            List<TResult> result = new List<TResult>();

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                result.Add(selector(item));
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result;
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(this IStack<T> stack, Func<T, IEnumerable<TResult>> selector)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            List<TResult> result = new List<TResult>();

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                IEnumerable<TResult> subResult = selector(item);
                result.AddRange(subResult);
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result;
        }

        public static bool All<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                if (!predicate(item))
                {
                    return false;
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return true;
        }

        public static bool Any<T>(this IStack<T> stack, Func<T, bool> predicate)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                if (predicate(item))
                {
                    return true;
                }
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return false;
        }

        public static T[] ToArray<T>(this IStack<T> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            List<T> result = new List<T>();

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                result.Add(item);
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result.ToArray();
        }

        public static List<T> ToList<T>(this IStack<T> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            List<T> result = new List<T>();

            IStack<T> tempStack = new GenericStack<T>();

            while (stack.Count > 0)
            {
                T item = stack.Pop();
                tempStack.Push(item);
                result.Add(item);
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result;
        }
    }
}
