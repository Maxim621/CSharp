using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class ListTest
    {
        [Test]
        public void Add_WhenItemAdded_CountIncreases()
        {
            // Arrange
            var list = new List<int>();

            // Act
            list.Add(5);

            // Assert
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Remove_WhenItemRemoved_CountDecreases()
        {
            // Arrange
            var list = new List<int>();
            list.Add(5);

            // Act
            list.Remove(5);

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void Contains_WhenItemExists_ReturnsTrue()
        {
            // Arrange
            var list = new List<string>();
            list.Add("apple");

            // Act
            bool result = list.Contains("apple");

            // Assert
            Assert.IsTrue(result);
        }

        // Додайте інші тести для інших методів та операцій.
    }

    [TestFixture]
    public class LinqExtensionsTests
    {
        [Test]
        public void Filter_WhenPredicateMatches_ReturnsFilteredItems()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var filtered = items.Filter(x => x % 2 == 0);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 2, 4 }, filtered);
        }

        [Test]
        public void Skip_WhenCountIs2_SkipsFirstTwoItems()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var skipped = items.Skip(2);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 3, 4, 5 }, skipped);
        }

        // Додайте інші тести для інших методів Linq.
    }
}
