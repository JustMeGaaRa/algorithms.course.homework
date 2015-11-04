using System.Collections.Generic;
using hamstr;
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
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            hamsters.Add(new Hamster(1, 2));
            hamsters.Add(new Hamster(2, 2));
            hamsters.Add(new Hamster(3, 1));

            // Act
            int result = cage.FeedHamsters(hamsters);

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
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            hamsters.Add(new Hamster(5, 0));
            hamsters.Add(new Hamster(2, 2));
            hamsters.Add(new Hamster(1, 4));
            hamsters.Add(new Hamster(5, 1));

            // Act
            int result = cage.FeedHamsters(hamsters);

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
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            hamsters.Add(new Hamster(1, 50000));
            hamsters.Add(new Hamster(1, 60000));

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 1;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case4()
        {
            // Assign
            int foodSupplies = 5;
            int hamsterCount = 5;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            hamsters.Add(new Hamster(1, 0));
            hamsters.Add(new Hamster(1, 0));
            hamsters.Add(new Hamster(1, 0));
            hamsters.Add(new Hamster(1, 0));
            hamsters.Add(new Hamster(1, 0));

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 5;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case5()
        {
            // Assign
            int foodSupplies = 65;
            int hamsterCount = 5;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);

            for (int i = 0; i < hamsterCount; i++)
            {
                hamsters.Add(new Hamster(1, i + 1));
            }

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 5;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case6()
        {
            // Assign
            int foodSupplies = 0;
            int hamsterCount = 10;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);

            for (int i = 0; i < hamsterCount; i++)
            {
                hamsters.Add(new Hamster(0, 0));
            }

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 10;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case7()
        {
            // Assign
            int foodSupplies = 1000000000;
            int hamsterCount = 10;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);

            for (int i = 0; i < hamsterCount; i++)
            {
                hamsters.Add(new Hamster(0, 0));
            }

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 10;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case8()
        {
            // Assign
            int foodSupplies = 0;
            int hamsterCount = 1;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);
            hamsters.Add(new Hamster(10, 0));

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 0;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case9()
        {
            // Assign
            int foodSupplies = 1000000000;
            int hamsterCount = 10;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);

            for (int i = 0; i < hamsterCount; i++)
            {
                hamsters.Add(new Hamster(1000000000, 1000000000));
            }

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 1;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case10()
        {
            // Assign
            int foodSupplies = 1000000000;
            int hamsterCount = 1000;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);

            for (int i = 0; i < hamsterCount; i++)
            {
                hamsters.Add(new Hamster(100000000, 1));
            }

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 9;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void FeedHamster_Case11()
        {
            // Assign
            int foodSupplies = 1000000000;
            int hamsterCount = 1;
            var hamsters = new List<Hamster>();
            var cage = new HamsterCage(foodSupplies, hamsterCount);

            for (int i = 0; i < hamsterCount; i++)
            {
                hamsters.Add(new Hamster(0, 1));
            }

            // Act
            int result = cage.FeedHamsters(hamsters);

            // Assert
            int expected = 1;
            var errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }
    }
}
