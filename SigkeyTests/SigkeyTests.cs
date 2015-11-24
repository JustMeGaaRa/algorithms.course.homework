using Microsoft.VisualStudio.TestTools.UnitTesting;
using sigkey;

namespace SigkeyTests
{
    [TestClass]
    public class SigkeyTests
    {
        [TestMethod]
        public void GetPairsCount_Case1()
        {
            // Assign
            var count = 4;
            var keys = new[] { "acdf", "bcde", "be", "f" };
            var expected = 1;
            var sigkey = new Sigkey();

            // Act
            var result = sigkey.GetPairsCount(count, keys);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPairsCount_Case2()
        {
            // Assign
            var count = 4;
            var keys = new[] { "bdfhj", "gacie", "bdf", "aec" };
            var expected = 2;
            var sigkey = new Sigkey();

            // Act
            var result = sigkey.GetPairsCount(count, keys);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPairsCount_Case3()
        {
            // Assign
            var count = 6;
            var keys = new[]
            {
                "abcdefghijklm",
                "nopqrstuvwxyz",
                "cba",
                "fed",
                "zyxwvutsr",
                "qponabcdefghijklm"
            };
            var expected = 3;
            var sigkey = new Sigkey();

            // Act
            var result = sigkey.GetPairsCount(count, keys);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetPairsCount_Case4()
        {
            // Assign
            var count = 26;
            var keys = new[]
            {
                "e", "m", "t", "i", "b", "l", "y",
                "p", "c", "o", "v", "j", "h", "k",
                "x", "r", "u", "a", "g", "w", "z",
                "q", "f", "s", "n", "d"
            };
            var expected = 1;
            var sigkey = new Sigkey();

            // Act
            var result = sigkey.GetPairsCount(count, keys);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
