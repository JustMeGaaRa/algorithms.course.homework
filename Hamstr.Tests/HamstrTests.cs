using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hamstr.Tests
{
    [TestClass]
    public class HamstrTests
    {
        [TestMethod]
        public void FeedHamster_Case1()
        {
            // Assign
            int foodSupplies = 7;
            int hamsterCount = 3;
            var hamsters = new List<Hamster>
            {
                new Hamster(1, 2, hamsterCount - 1),
                new Hamster(2, 2, hamsterCount - 1),
                new Hamster(3, 1, hamsterCount - 1)
            };
            var hamstr = new Hamstr();

            // Act
            int result = hamstr.FeedHamsters(foodSupplies, hamsterCount, hamsters);

            // Assert
            int expected = 2;
            var errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case2()
        {
            // Assign
            int foodSupplies = 19;
            int hamsterCount = 4;
            var hamsters = new List<Hamster>
            {
                new Hamster(5, 0, hamsterCount - 1),
                new Hamster(2, 2, hamsterCount - 1),
                new Hamster(1, 4, hamsterCount - 1),
                new Hamster(5, 1, hamsterCount - 1)
            };
            var hamstr = new Hamstr();

            // Act
            int result = hamstr.FeedHamsters(foodSupplies, hamsterCount, hamsters);

            // Assert
            int expected = 3;
            var errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case3()
        {
            // Assign
            int foodSupplies = 2;
            int hamsterCount = 2;
            var hamsters = new List<Hamster>
            {
                new Hamster(1, 50000, hamsterCount - 1),
                new Hamster(1, 60000, hamsterCount - 1)
            };
            var hamstr = new Hamstr();

            // Act
            int result = hamstr.FeedHamsters(foodSupplies, hamsterCount, hamsters);

            // Assert
            int expected = 1;
            var errorMessage = $"Expected: {expected:F}, Actual: {result:F}";
            Assert.AreEqual(expected, result, errorMessage);
        }
    }
}
