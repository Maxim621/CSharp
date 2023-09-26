using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void Add_AddsElementToList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();

            // Act
            list.Add(42);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(42, list[0]);
        }

        [TestMethod]
        public void Remove_RemovesElementFromList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // Act
            list.Remove(20);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(10, list[0]);
            Assert.AreEqual(30, list[1]);
        }

        [TestMethod]
        public void Clear_EmptiesTheList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Add_AddsElementToEmptyList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();

            // Act
            list.Add(42);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(42, list[0]);
        }

        [TestMethod]
        public void Add_AddsMultipleElementsToList()
        {
            // Arrange
            LinkedList<int> list = new LinkedList<int>();

            // Act
            list.Add(10);
            list.Add(20);
            list.Add(30);

            // Assert
            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(10, list[0]);
            Assert.AreEqual(20, list[1]);
            Assert.AreEqual(30, list[2]);
        }
    }
}
