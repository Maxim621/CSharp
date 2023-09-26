using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestFixture]
    public class QueueTest
    {
        [Test]
        public void Enqueue_Dequeue()
        {
            IQueue<int> queue = new GenericQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
        }

        [Test]
        public void Peek_Count()
        {
            IQueue<string> queue = new GenericQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");

            Assert.AreEqual("first", queue.Peek());
            Assert.AreEqual(2, queue.Count);
        }

        [Test]
        public void Clear()
        {
            IQueue<double> queue = new GenericQueue<double>();
            queue.Enqueue(3.14);
            queue.Enqueue(2.71);

            queue.Clear();

            Assert.AreEqual(0, queue.Count);
            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Filter_CustomLinqExtension()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> filteredNumbers = numbers.Filter(x => x % 2 == 0);

            CollectionAssert.AreEqual(new[] { 2, 4, 6, 8, 10 }, filteredNumbers);
        }

        [Test]
        public void Skip_CustomLinqExtension()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> skippedNumbers = numbers.Skip(3);

            CollectionAssert.AreEqual(new[] { 4, 5, 6, 7, 8, 9, 10 }, skippedNumbers);
        }

        [Test]
        public void Take_CustomLinqExtension()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> takenNumbers = numbers.Take(5);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, takenNumbers);
        }
    }
