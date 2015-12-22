using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonTests
{
    using Common.DataStructures;

    [TestClass]
    public class VertexTests
    {
        [TestMethod]
        public void Vertex_Equals_IsFalse_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("b");

            // Act
            bool actual = vertexA.Equals(vertexB);

            // Assert
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vertex_Equals_IsTrue_Test()
        {
            // Assign
            var vertexA = new Vertex("a");
            var vertexB = new Vertex("a");

            // Act
            bool actual = vertexA.Equals(vertexB);

            // Assert
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
