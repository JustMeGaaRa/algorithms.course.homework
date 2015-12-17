using System.Collections.Generic;
using System.Linq;
using Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    [TestClass]
    public class GraphExtensionsTests
    {
        [TestMethod]
        public void BreadthFirstSearch_Test()
        {
            // Assign
            var graph = CreateTestGraph();

            // Act
            var vertices = graph.BreadthFirstSearch(graph.Vertices.First(), graph.Vertices.Last());
            var actual = vertices.Select(vectex => vectex.Label).Aggregate((x, y) => x + y);

            // Assert
            var expected = "abcdefg";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DepthFirstSearch_Test()
        {
            // Assign
            var graph = CreateTestGraph();

            // Act
            var vertices = graph.DepthFirstSearch(graph.Vertices.First(), graph.Vertices.Last());
            var actual = vertices.Select(vectex => vectex.Label).Aggregate((x, y) => x + y);

            // Assert
            var expected = "acgfbed";
            Assert.AreEqual(expected, actual);
        }

        private Graph CreateTestGraph()
        {
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");
            var vertexC = new Vertex("c");
            var vertexD = new Vertex("d");
            var vertexE = new Vertex("e");
            var vertexF = new Vertex("f");
            var vertexG = new Vertex("g");

            var edgeAB = new Edge(vertexA, vertexB, 0);
            var edgeAC = new Edge(vertexA, vertexC, 0);
            var edgeBD = new Edge(vertexB, vertexD, 0);
            var edgeBE = new Edge(vertexB, vertexE, 0);
            var edgeCF = new Edge(vertexC, vertexF, 0);
            var edgeCG = new Edge(vertexC, vertexG, 0);

            var graph = new Graph();
            graph.Vertices.Add(vertexA);
            graph.Vertices.Add(vertexB);
            graph.Vertices.Add(vertexC);
            graph.Vertices.Add(vertexD);
            graph.Vertices.Add(vertexE);
            graph.Vertices.Add(vertexF);

            graph.AddEdge(edgeAB);
            graph.AddEdge(edgeAC);
            graph.AddEdge(edgeBD);
            graph.AddEdge(edgeBE);
            graph.AddEdge(edgeCF);
            graph.AddEdge(edgeCG);

            return graph;
        }
    }
}