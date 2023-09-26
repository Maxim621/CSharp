using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestFixture]
    public class ObservableListTest
    {
        [Test]
        public void LinqExtensions_Filter_ShouldFilterItemsAccordingToPredicate()
        {
            // Тест для методу Filter з LinqExtensions
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Act
            IEnumerable<int> filteredNumbers = numbers.Filter(x => x % 2 == 0);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 2, 4, 6, 8, 10 }, filteredNumbers);
        }

        [Test]
        public void ListExtensions_Sort_ShouldSortListInAscendingOrder()
        {
            // Тест для методу Sort з ListExtensions
            // Arrange
            List<int> numbers = new List<int> { 5, 2, 8, 3, 1, 7, 4, 6, 9, 10 };

            // Act
            numbers.Sort();

            // Assert
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, numbers);
        }

        [Test]
        public void YieldLinqExtensions_YieldFilter_ShouldFilterItemsAccordingToPredicate()
        {
            // Тест для методу YieldFilter з YieldLinqExtensions
            // Arrange
            List<string> fruits = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };

            // Act
            IEnumerable<string> filteredFruits = fruits.YieldFilter(fruit => fruit.Length > 5);

            // Assert
            CollectionAssert.AreEqual(new List<string> { "banana", "cherry", "elderberry" }, filteredFruits);
        }
    }
}
