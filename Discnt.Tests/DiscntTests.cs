using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Discnt.Tests
{
    [TestClass]
    public class DiscntTests
    {
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
        public void GetMinPrice_WithZeroDiscount()
        {
            // Assign
            var discnt = new discnt.Discnt();
            int[] prices = { 300, 300, 300, 300, 300, 300, 300, 300, 300 };
            int discount = 0;

            // Act
            double result = discnt.GetMinPrice(prices, discount);

            // Assert
            double expected = 2700;
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
