using Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    [TestClass]
    public class EdgeTests
    {
        [TestMethod]
        public void Ctor_WithParameters_ShouldSetItselfAsParent_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");
            var edge = new Edge(vertexA, vertexB, 0);

            // Act
            bool actual = vertexA.InboundEdges.Contains(edge);
            actual &= vertexA.OutboundEdges.Contains(edge);
            actual &= vertexB.InboundEdges.Contains(edge);
            actual &= vertexB.OutboundEdges.Contains(edge);

            // Assert
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WithDifferentVertices_IsFalse_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");
            var edgeA = new Edge(vertexA, vertexA, 0);
            var edgeB = new Edge(vertexB, vertexB, 0);

            // Act
            bool actual = edgeA.Equals(edgeB);

            // Assert
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WithCrossDifferentVertices_IsFalse_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");
            var edgeA = new Edge(vertexA, vertexB, 0);
            var edgeB = new Edge(vertexB, vertexA, 0);

            // Act
            bool actual = edgeA.Equals(edgeB);

            // Assert
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WithDifferentWeight_IsFalse_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");
            var edgeA = new Edge(vertexA, vertexB, 10);
            var edgeB = new Edge(vertexA, vertexB, 20);

            // Act
            bool actual = edgeA.Equals(edgeB);

            // Assert
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Equals_WithSameVerticesAndWeight_IsTrue_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");
            var edgeA = new Edge(vertexA, vertexB, 0);
            var edgeB = new Edge(vertexA, vertexB, 0);

            // Act
            bool actual = edgeA.Equals(edgeB);

            // Assert
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}