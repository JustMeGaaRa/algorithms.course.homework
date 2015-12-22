using System;
using System.Linq;
using Common.Algorithms;
using Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Govern.Tests
{
    [TestClass]
    public class GovernTests
    {
        [TestMethod]
        public void Tarjans_Case1()
        {
            // Assign
            var lines = new[]
            {
                "visa foreignpassport",
                "visa hotel",
                "visa bankstatement",
                "bankstatement nationalpassport",
                "hotel creditcard",
                "creditcard nationalpassport",
                "nationalpassport birthcertificate",
                "foreignpassport nationalpassport",
                "foreignpassport militarycertificate",
                "militarycertificate nationalpassport"
            };
            var graph = new Graph();
            var expectedStrings = new[]
            {
                "birthcertificate",
                "nationalpassport",
                "militarycertificate",
                "foreignpassport",
                "creditcard",
                "hotel",
                "bankstatement",
                "visa"
            };
            var expected = expectedStrings.Aggregate((x, y) => x + Environment.NewLine + y);

            // Act
            graph.Parse(lines);
            var result = graph.Tarjan();
            var actual = result.Select(x => x.Label).Aggregate((x, y) => x + Environment.NewLine + y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tarjans_Case2()
        {
            // Assign
            var lines = new[]
            {
                "visa foreignpassport"
            };
            var graph = new Graph();
            var expectedStrings = new[]
            {
                "foreignpassport",
                "visa"
            };
            var expected = expectedStrings.Aggregate((x, y) => x + Environment.NewLine + y);

            // Act
            graph.Parse(lines);
            var result = graph.Tarjan();
            var actual = result.Select(x => x.Label).Aggregate((x, y) => x + Environment.NewLine + y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tarjans_Case3()
        {
            // Assign
            var lines = new[]
            {
                "cer03 cer09", "cer03 cer08", "cer03 cer07",
                "cer02 cer06", "cer02 cer05", "cer02 cer04",
                "cer01 cer03", "cer01 cer02"
            };
            var graph = new Graph();
            var expectedStrings = new[]
            {
                "cer09", "cer08", "cer07", "cer03",
                "cer06", "cer05", "cer04", "cer02",
                "cer01"
            };
            var expected = expectedStrings.Aggregate((x, y) => x + Environment.NewLine + y);

            // Act
            graph.Parse(lines);
            var result = graph.Tarjan();
            var actual = result.Select(x => x.Label).Aggregate((x, y) => x + Environment.NewLine + y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tarjans_Case4()
        {
            // Assign
            var lines = new[]
            {
                "3a 4a", "3a 4b", "3b 4c", "3b 4d", "3c 4e",
                "3c 4f", "3d 4g", "3d 4h", "2a 3a", "2a 3b",
                "2b 3c", "2b 3d", "1a 2a", "1a 2b", "y z", "x v"
            };
            var graph = new Graph();
            var expectedStrings = new[]
            {
                "4a", "4b", "3a", "4c", "4d", "3b",
                "4e", "4f", "3c", "4g", "4h", "3d",
                "2a", "2b", "1a", "z", "y", "v", "x"
            };
            var expected = expectedStrings.Aggregate((x, y) => x + Environment.NewLine + y);

            // Act
            graph.Parse(lines);
            var result = graph.Tarjan();
            var actual = result.Select(x => x.Label).Aggregate((x, y) => x + Environment.NewLine + y);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Tarjans_Case5()
        {
            // Assign
            var lines = new[]
            {
                "a b", "c d", "e f", "g h", "i j", "k l", "m n",
                "o p", "q r", "s t", "u v", "w x", "y z"
            };
            var graph = new Graph();
            var expectedStrings = new[]
            {
                "b", "a", "d", "c", "f", "e", "h", "g", "j", "i", "l", "k", "n",
                "m", "p", "o", "r", "q", "t", "s", "v", "u", "x", "w", "z", "y"
            };
            var expected = expectedStrings.Aggregate((x, y) => x + Environment.NewLine + y);

            // Act
            graph.Parse(lines);
            var result = graph.Tarjan();
            var actual = result.Select(x => x.Label).Aggregate((x, y) => x + Environment.NewLine + y);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
