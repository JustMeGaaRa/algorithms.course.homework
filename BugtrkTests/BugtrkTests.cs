using bugtrk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BugtrkTests
{
    [TestClass]
    public class BugtrkTests
    {
        [TestMethod]
        public void FindMinLength_Case1()
        {
            // Assign
            long count = 10;
            int width = 2;
            int height = 3;
            var expected = 9;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case2()
        {
            // Assign
            long count = 2;
            int width = 1000000000;
            int height = 999999999;
            var expected = 1999999998;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case3()
        {
            // Assign
            long count = 4;
            int width = 1;
            int height = 1;
            var expected = 2;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case4()
        {
            // Assign
            long count = 32416188257;
            int width = 105143;
            int height = 15489949;
            var expected = 229777903466;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case5()
        {
            // Assign
            long count = 100;
            int width = 1000000000;
            int height = 1;
            var expected = 1000000000;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case6()
        {
            // Assign
            long count = 1;
            int width = 1;
            int height = 999999999;
            var expected = 999999999;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case7()
        {
            // Assign
            long count = 1000000000000;
            int width = 1000000000;
            int height = 1000000000;
            var expected = 1000000000000000;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case8()
        {
            // Assign
            long count = 1000000000000;
            int width = 1;
            int height = 1;
            var expected = 1000000;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case9()
        {
            // Assign
            long count = 1;
            int width = 1;
            int height = 1;
            var expected = 1;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case10()
        {
            // Assign
            long count = 626;
            int width = 1;
            int height = 1;
            var expected = 26;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case11()
        {
            // Assign
            long count = 1000000000000;
            int width = 999;
            int height = 999;
            var expected = 999000000;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindMinLength_Case12()
        {
            // Assign
            long count = 998001;
            int width = 1000000000;
            int height = 1000000000;
            var expected = 999000000000;
            var bugtrk = new Bugtrk();

            // Act
            var result = bugtrk.FindMinLength(count, width, height);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
