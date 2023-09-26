using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTest
{
    [TestFixture]
    public class PriorityQueueTest
    {
        [Test]
        public void Collection_Add_AddsItemToCollection()
        {
            // Arrange
            var collection = new MyCollection<int>();
            int itemToAdd = 42;

            // Act
            collection.Add(itemToAdd);

            // Assert
            Assert.IsTrue(collection.Contains(itemToAdd));
        }

        [Test]
        public void Collection_Remove_RemovesItemFromCollection()
        {
            // Arrange
            var collection = new MyCollection<int> { 1, 2, 3 };
            int itemToRemove = 2;

            // Act
            collection.Remove(itemToRemove);

            // Assert
            Assert.IsFalse(collection.Contains(itemToRemove));
        }

        [Test]
        public void Linq_Filter_FiltersCollectionBasedOnPredicate()
        {
            // Arrange
            var collection = new MyCollection<int> { 1, 2, 3, 4, 5 };

            // Act
            var filtered = collection.Filter(x => x % 2 == 0);

            // Assert
            Assert.AreEqual(2, filtered.Count());
            Assert.IsTrue(filtered.All(x => x % 2 == 0));
        }

        [Test]
        public void Linq_Skip_SkipsElementsInCollection()
        {
            // Arrange
            var collection = new MyCollection<int> { 1, 2, 3, 4, 5 };

            // Act
            var skipped = collection.Skip(2);

            // Assert
            Assert.AreEqual(3, skipped.Count());
            Assert.IsTrue(skipped.All(x => x >= 3));
        }
    }
}
