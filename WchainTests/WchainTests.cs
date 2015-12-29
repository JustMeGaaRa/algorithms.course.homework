using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using wchain;

namespace WchainTests
{
    [TestClass]
    public class WchainTests
    {
        [TestMethod]
        public void FindMaximumChainLength_Case1()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[]
                            {
                                "10", "crates", "car", "cats", "crate",
                                "rate", "at", "ate", "tea", "rat", "a"
                            };
            var expected = 6;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case2()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[] { "5", "b", "bcad", "bca", "bad", "bd" };
            var expected = 4;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case3()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[] { "3", "word", "anotherword", "yetanotherword" };
            var expected = 1;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case4()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[] { "6", "a", "b", "ba", "bca", "bda", "bdca" };
            var expected = 4;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case5()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[] { "7", "e", "bca", "f", "ba", "bda", "bdefgh", "bdca" };
            var expected = 3;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case6()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[] { "3", "a", "b", "c" };
            var expected = 1;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case7()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new[] { "7", "a", "b", "c", "d", "e", "dea", "de" };
            var expected = 3;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumChainLength_Case8()
        {
            // Assign
            var wchain = new Wchain();
            var lines = new string[51];
            lines[0] = "50";

            for (int i = 1; i < 51; i++)
            {
                lines[i] = new string('a', i);
            }

            var expected = 50;

            // Act
            var actual = wchain.FindMaximumChainLength(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
