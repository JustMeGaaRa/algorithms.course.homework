using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lngpok.Tests
{
    [TestClass]
    public class LngpokTests
    {
        [TestMethod]
        public void GetMaxStreak_Case1()
        {
            // Assign
            int[] values = { 0, 10, 15, 50, 0, 14, 9, 12, 40 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 7;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case2()
        {
            // Assign
            int[] values = { 1, 1, 1, 2, 1, 1, 3 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 3;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case3()
        {
            // Assign
            int[] values = { 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 0, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 4;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case4()
        {
            // Assign
            int[] values = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 9;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case5()
        {
            // Assign
            int[] values = Enumerable.Range(1, 10).ToArray();
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 10;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case6()
        {
            // Assign
            int[] values = { 0, 0, 1, 0, 0, 5, 6, 8, 11, 12, 13, 14, 15, 17, 20 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 13;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case7()
        {
            // Assign
            int[] values = { 0, 50, 3, 0, 46, 47, 7, 8, 14, 17, 23, 1, 2, 45 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 5;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }
    }
}
