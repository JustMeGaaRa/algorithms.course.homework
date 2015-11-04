using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hamstr.Tests
{
    [TestClass]
    public class HamsterCageTests
    {
        [TestMethod]
        public void FeedHamster_Case1()
        {
            // Assign
            int foodSupplies = 7;
            int hamsterCount = 3;
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            cage.AddHamster(1, 2);
            cage.AddHamster(2, 2);
            cage.AddHamster(3, 1);

            // Act
            int result = cage.FeedHamsters();

            // Assert
            int expected = 2;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case2()
        {
            // Assign
            int foodSupplies = 19;
            int hamsterCount = 4;
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            cage.AddHamster(5, 0);
            cage.AddHamster(2, 2);
            cage.AddHamster(1, 4);
            cage.AddHamster(5, 1);

            // Act
            int result = cage.FeedHamsters();

            // Assert
            int expected = 3;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case3()
        {
            // Assign
            int foodSupplies = 2;
            int hamsterCount = 2;
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            cage.AddHamster(1, 50000);
            cage.AddHamster(1, 60000);

            // Act
            int result = cage.FeedHamsters();

            // Assert
            int expected = 1;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }
    }
}
