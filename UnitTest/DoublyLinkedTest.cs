using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class DoublyLinkedListTest
    {
        [Test]
        public void TestAdd()
        {
            // Arrange
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            // Act
            list.Add(10);
            list.Add(20);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(10, list.First);
            Assert.AreEqual(20, list.Last);
        }

        [Test]
        public void TestRemove()
        {
            // Arrange
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(10);
            list.Add(20);

            // Act
            bool result = list.Remove(10);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(20, list.First);
            Assert.AreEqual(20, list.Last);
        }

        [Test]
        public void TestToArray()
        {
            // Arrange
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(10);
            list.Add(20);

            // Act
            int[] array = list.ToArray();

            // Assert
            CollectionAssert.AreEqual(new[] { 10, 20 }, array);
        }
    }
}
