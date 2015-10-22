using System.Linq;
using discnt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Discnt.Tests
{
    [TestClass]
    public class DiscntTests
    {
        private const string ArraysMismatchMessage = "Arrays mismatch!";

        private int[] GetShuffledArray()
        {
            return new[]
            {
                389, 100, 331, 340, 325, 331, 462,
                307, 457, 86, 398, 232, 97, 449, 14,
                236, 491, 126, 339, 187, 64, 142, 498,
                433, 437, 343, 401, 199, 138, 167,
                21, 306, 75, 105, 392, 430, 73, 271,
                479, 201, 252, 2, 101, 219, 472, 146,
                21, 40, 444, 436, 202, 479, 104, 227,
                130, 246, 102, 397, 403, 481, 429,
                263, 168, 290, 65, 91, 157, 491, 57,
                84, 162, 220, 147, 138, 435, 62, 41,
                278, 461, 290, 321, 361, 255, 202,
                464, 41, 201, 347, 475, 145, 327, 175,
                367, 497, 271, 489, 333, 311, 153, 380
            };
        }

        private int[] GetSortedArray()
        {
            return new[]
            {
                2, 14, 21, 21, 40, 41, 41, 57, 62, 64,
                65, 73, 75, 84, 86, 91, 97, 100, 101,
                102, 104, 105, 126, 130, 138, 138, 142,
                145, 146, 147, 153, 157, 162, 167, 168,
                175, 187, 199, 201, 201, 202, 202, 219,
                220, 227, 232, 236, 246, 252, 255, 263,
                271, 271, 278, 290, 290, 306, 307, 311,
                321, 325, 327, 331, 331, 333, 339, 340,
                343, 347, 361, 367, 380, 389, 392, 397,
                398, 401, 403, 429, 430, 433, 435, 436,
                437, 444, 449, 457, 461, 462, 464, 472,
                475, 479, 479, 481, 489, 491, 491, 497, 498
            };
        }

        [TestMethod]
        public void SelectionSort_ShouldSort()
        {
            // Assign
            var shuffled = GetShuffledArray();
            var sorted = GetSortedArray();

            // Act
            Arrays.SelectionSort(shuffled);

            // Assert
            Assert.IsTrue(shuffled.SequenceEqual(sorted), ArraysMismatchMessage);
        }

        [TestMethod]
        public void InsertionSort_ShouldSort()
        {
            // Assign
            var shuffled = GetShuffledArray();
            var sorted = GetSortedArray();

            // Act
            Arrays.InsertionSort(shuffled);

            // Assert
            Assert.IsTrue(shuffled.SequenceEqual(sorted), ArraysMismatchMessage);
        }

        [TestMethod]
        public void BubbleSort_ShouldSort()
        {
            // Assign
            var shuffled = GetShuffledArray();
            var sorted = GetSortedArray();

            // Act
            Arrays.BubbleSort(shuffled);

            // Assert
            Assert.IsTrue(shuffled.SequenceEqual(sorted), ArraysMismatchMessage);
        }

        [TestMethod]
        public void GetMinPrice_With11Prices()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 300, 499, 129, 237, 327, 900, 153, 987, 8765, 530, 1234 };
            int discount = 30;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 10765.20;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_With10Prices()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 300, 499, 129, 237, 327, 900, 153, 987, 8765, 530 };
            int discount = 30;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 9631.4;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_With9Prices()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 300, 499, 129, 237, 327, 900, 153, 987, 8765 };
            int discount = 30;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 9101.4;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_WithZeroPrices()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { };
            int discount = 30;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 0;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_WithOnePrice()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 300 };
            int discount = 30;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 300;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_Case1()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 50, 20, 30, 17, 100 };
            int discount = 10;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 207;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_Case2()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 1, 2, 3, 4, 5, 6, 7 };
            int discount = 100;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 15;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMinPrice_Case3()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 1, 1, 1 };
            int discount = 33;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 2.67;
            string errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }
    }
}
