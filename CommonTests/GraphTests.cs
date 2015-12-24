using System.Linq;
using Common.Algorithms;
using Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void Parse_WithoutWeight_ShouldParse_Test()
        {
            // Assign
            var lines = new[] { "1 2", "2 3", "3 1" };
            var graph = new Graph();

            // Act
            graph.Parse(lines, true);

            // Assert
            Assert.AreEqual(3, graph.Vertices.Count());
            Assert.AreEqual(3, graph.Edges.Count());
        }

        [TestMethod]
        public void Parse_WithWeight_ShouldParse_Test()
        {
            // Assign
            var lines = new[] { "1 2 10", "2 3 15", "3 1 20" };
            var graph = new Graph();

            // Act
            graph.Parse(lines, true);

            // Assert
            Assert.AreEqual(3, graph.Vertices.Count());
            Assert.AreEqual(3, graph.Edges.Count());
        }
    }
}