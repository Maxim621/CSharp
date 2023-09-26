using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestFixture]
    public class TreeTest
    {
        [Test]
        public void Add_AddingElements_IncreasesCount()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);

            Assert.AreEqual(3, tree.Count);
        }

        [Test]
        public void Contains_ExistingElement_ReturnsTrue()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);

            Assert.IsTrue(tree.Contains(3));
        }

        [Test]
        public void Contains_NonExistingElement_ReturnsFalse()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);

            Assert.IsFalse(tree.Contains(10));
        }
    }

    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Filter_FilterEvenNumbers_ReturnsFilteredSequence()
        {
            var data = new int[] { 1, 2, 3, 4, 5, 6 };
            var filtered = data.Filter(x => x % 2 == 0);

            Assert.AreEqual(new int[] { 2, 4, 6 }, filtered);
        }

        [Test]
        public void Take_Take3Elements_ReturnsFirst3Elements()
        {
            var data = new int[] { 1, 2, 3, 4, 5 };
            var taken = data.Take(3);

            Assert.AreEqual(new int[] { 1, 2, 3 }, taken);
        }
    }
}
