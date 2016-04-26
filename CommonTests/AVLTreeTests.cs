using System.Collections.Generic;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    [TestClass]
    public class AvlTreeTests
    {
        [TestMethod]
        public void Insert_Integers_ShouldBeAdded()
        {
            // Arrange
            IComparer<int> comparerFake = CreateIntegerComparerFake();
            AvlTree<int> tree = new AvlTree<int>(comparerFake);

            // Act
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(2);
            tree.Insert(8);
            tree.Insert(3);

            // Assert
            int expectedCount = 6;
            int expectedHeight = 3;
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedHeight, tree.Height);
        }

        [TestMethod]
        public void Insert_SortedIntegers_ShouldBeBallanced()
        {
            // Arrange
            IComparer<int> comparerFake = CreateIntegerComparerFake();
            AvlTree<int> tree = new AvlTree<int>(comparerFake);

            // Act
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);

            // Assert
            int expectedCount = 6;
            int expectedHeight = 3;
            Assert.AreEqual(expectedCount, tree.Count);
            Assert.AreEqual(expectedHeight, tree.Height);
        }

        private IComparer<int> CreateIntegerComparerFake()
        {
            return Comparer<int>.Create((left, right) =>
                {
                    if (left < right)
                    {
                        return -1;
                    }

                    if (left > right)
                    {
                        return 1;
                    }

                    return 0;
                });
        }
    }
}
