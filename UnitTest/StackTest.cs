using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    [TestFixture]
    public class StackTest
    {
        [Test]
        public void PushAndPopItems()
        {
            // Arrange
            var stack = new GenericStack<int>();

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var poppedItem = stack.Pop();

            // Assert
            Assert.AreEqual(3, poppedItem);
            Assert.AreEqual(2, stack.Count);
        }

        [Test]
        public void PeekReturnsTopItem()
        {
            // Arrange
            var stack = new GenericStack<string>();

            // Act
            stack.Push("Item 1");
            stack.Push("Item 2");

            var peekedItem = stack.Peek();

            // Assert
            Assert.AreEqual("Item 2", peekedItem);
            Assert.AreEqual(2, stack.Count);
        }

        [Test]
        public void FilterRemovesItemsBasedOnPredicate()
        {
            // Arrange
            var stack = new GenericStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            // Act
            stack.Filter(x => x % 2 == 0);

            // Assert
            Assert.AreEqual(2, stack.Count);
            Assert.IsFalse(stack.Contains(1));
            Assert.IsFalse(stack.Contains(3));
            Assert.IsTrue(stack.Contains(2));
            Assert.IsTrue(stack.Contains(4));
        }

        [Test]
        public void SkipSkipsSpecifiedNumberOfItems()
        {
            // Arrange
            var stack = new GenericStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            // Act
            stack.Skip(2);

            // Assert
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(3, stack.Peek());
        }

        [Test]
        public void TakeTakesSpecifiedNumberOfItems()
        {
            // Arrange
            var stack = new GenericStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            // Act
            stack.Take(2);

            // Assert
            Assert.AreEqual(2, stack.Count);
            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void SelectAppliesSelectorFunction()
        {
            // Arrange
            var stack = new GenericStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            var squaredNumbers = stack.Select(x => x * x);

            // Assert
            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(9, squaredNumbers.ElementAt(0));
            Assert.AreEqual(4, squaredNumbers.ElementAt(1));
            Assert.AreEqual(1, squaredNumbers.ElementAt(2));
        }
    }
}
