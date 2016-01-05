using System.Linq;

using career;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CareerTests
{
    [TestClass]
    public class CareerTests
    {
        [TestMethod]
        public void FindMaximumExpirience_Case1()
        {
            // Assign
            var career = new Career();
            var lines = new[]
                            {
                                "4",
                                "4",
                                "3 1",
                                "2 1 5",
                                "1 3 2 1"
                            };
            var expected = 12;

            // Act
            var actual = career.FindMaximumExpirience(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumExpirience_Case2()
        {
            // Assign
            var career = new Career();
            var lines = new[]
                            {
                                "1",
                                "9999",
                            };
            var expected = 9999;

            // Act
            var actual = career.FindMaximumExpirience(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumExpirience_Case3()
        {
            // Assign
            var career = new Career();
            var lines = new[]
                            {
                                "5",
                                "0",
                                "1 1",
                                "0 0 0",
                                "1 1 1 1",
                                "0 1 0 1 0"
                            };
            var expected = 3;

            // Act
            var actual = career.FindMaximumExpirience(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumExpirience_Case4()
        {
            // Assign
            var career = new Career();
            var lines = new[]
                            {
                                "7",
                                "1",
                                "5 2",
                                "4 0 10",
                                "3 2 8 1",
                                "8 1 7 4 1",
                                "1 1 5 3 1 1",
                                "1 1 1 1 1 1 1",
                            };
            var expected = 34;

            // Act
            var actual = career.FindMaximumExpirience(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaximumExpirience_Case5()
        {
            // Assign
            var career = new Career();
            var lines = new string[1001];
            lines[0] = "1000";
            for (int i = 1; i <= 1000; i++)
            {
                lines[i] = Enumerable.Repeat("9999", i).Aggregate((x, y) => $"{x} {y}");
            }
            var expected = 9999000;

            // Act
            var actual = career.FindMaximumExpirience(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
