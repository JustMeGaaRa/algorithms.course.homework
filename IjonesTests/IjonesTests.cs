using ijones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IjonesTests
{
    [TestClass]
    public class IjonesTests
    {
        [TestMethod]
        public void Solve_Case1()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 5;
            int width = 3;
            int height = 3;
            var corridor = new[] { "aaa", "cab", "def" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case2()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 2;
            int width = 10;
            int height = 1;
            var corridor = new[] { "abcdefaghi" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case3()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 72;
            int width = 4;
            int height = 4;
            var corridor = new[] { "aaaa", "abba", "abba", "aaaa" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case4()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 2;
            int width = 5;
            int height = 5;
            var corridor = new[] { "abcde", "fghij", "klmno", "pqrst", "uvwxy" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case5()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 218;
            int width = 6;
            int height = 5;
            var corridor = new[] { "abcdea", "faghai", "jkaalm", "naopaq", "arstua" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case6()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 201684;
            int width = 7;
            int height = 6;
            var corridor = new[] { "aaaaaaa", "aaaaaaa", "aaaaaaa", "aaaaaaa", "aaaaaaa", "aaaaaaa" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case7()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 1;
            int width = 1;
            int height = 1;
            var corridor = new[] { "a" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case8()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 2;
            int width = 1;
            int height = 3;
            var corridor = new[] { "a", "a", "a" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Solve_Case9()
        {
            // Assign
            var ijones = new Ijones();
            var expected = 64;
            int width = 4;
            int height = 4;
            var corridor = new[] { "abba", "baab", "baab", "abba" };

            // Act
            var actual = ijones.Solve(corridor, width, height);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
