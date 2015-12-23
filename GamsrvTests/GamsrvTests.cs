using System.Collections.Generic;
using System.Linq;
using System.Text;
using gamsrv;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GamsrvTests
{
    [TestClass]
    public class GamsrvTests
    {
        [TestMethod]
        public void FindMinimumLatency_Case1()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "6 6", "1 2 6", "1 3 10", "3 4 80", "4 5 50",
                "5 6 20", "2 3 40", "2 4 100"
            };
            int expected = 100;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case2()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "9 12", "2 4 6", "1 2 20", "2 3 20", "3 6 20",
                "6 9 20", "9 8 20", "8 7 20", "7 4 20", "4 1 20",
                "5 2 10", "5 4 10", "5 6 10", "5 8 10"
            };
            int expected = 10;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case3()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "3 2", "1 3", "1 2 100", "3 2 200"
            };
            int expected = 200;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case4()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "5 8", "1 2 4 5", "1 2 20", "2 4 20",
                "4 5 20", "5 1 20", "1 3 10", "2 3 10",
                "3 4 10", "3 5 10"
            };
            int expected = 10;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case5()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "5 8", "1 3 4 5", "1 2 20", "2 4 20",
                "4 5 20", "5 1 20", "1 3 10", "2 3 10",
                "3 4 10", "3 5 10"
            };
            int expected = 20;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case6()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "5 8", "1 3 4 5", "1 2 20", "2 4 20",
                "4 5 20", "5 1 20", "1 3 100", "2 3 30",
                "3 4 100", "3 5 100"
            };
            int expected = 40;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case7()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new List<string> { "100 99" };
            lines.Add(Enumerable.Range(1, 99).Select(x => x.ToString()).Aggregate((x, y) => $"{x} {y}"));
            lines.AddRange(Enumerable.Range(1, 99).Select(x => $"{x} {x + 1} 1000000000"));

            long expected = 99000000000;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines.ToArray());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMinimumLatency_Case9()
        {
            // Assign
            var gamsrv = new Gamsrv();
            var lines = new[]
            {
                "25 40", "1 2 3 4 5 6 10 11 15 16 20 21 22 23 24 25",
                "1 2 10", "2 3 10", "3 4 10", "4 5 10", "1 6 10", "2 7 10", "6 7 10",
                "3 8 10", "7 8 10", "4 9 10", "8 9 10", "5 10 10", "9 10 10", "6 11 10",
                "7 12 10", "11 12 10", "8 13 10", "12 13 10", "9 14 10", "13 14 10",
                "10 15 10", "14 15 10", "11 16 10", "12 17 10", "16 17 10", "13 18 10",
                "17 18 10", "14 19 10", "18 19 10", "15 20 10", "19 20 10", "16 21 10",
                "17 22 10", "21 22 10", "18 23 10", "22 23 10", "19 24 10", "23 24 10",
                "20 25 10", "24 25 10"
            };
            long expected = 40;

            // Act
            var actual = gamsrv.FindMinimumLatency(lines.ToArray());

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
