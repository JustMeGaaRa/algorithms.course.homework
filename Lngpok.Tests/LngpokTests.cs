using System;
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
    }
}
