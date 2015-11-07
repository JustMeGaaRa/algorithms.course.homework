using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lngpok.Tests
{
    [TestClass]
    public class LngpokTests
    {
        [TestMethod]
        public void GetMaxStreak_Case1()
        {
            // Assign
            int[] values = { 0, 10, 15, 50, 0, 14, 9, 12, 40 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 7;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case2()
        {
            // Assign
            int[] values = { 1, 1, 1, 2, 1, 1, 3 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 3;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case3()
        {
            // Assign
            int[] values = { 5, 6, 5, 6, 5, 6, 5, 6, 5, 6, 5, 0, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 4;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case4()
        {
            // Assign
            int[] values = { 20, 15, 10, 7, 5, 3, 1, 0, 0, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 7;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case5()
        {
            // Assign
            int[] values = { 0, 8, 7, 0, 3, 1, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 6;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case6()
        {
            // Assign
            int[] values = { 15, 10, 8, 0, 0, 0, 7, 3, 2, 1, 0, 0, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 12;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case7()
        {
            // Assign
            int[] values = { 19, 15, 0, 11, 9, 0, 7, 4, 0, 1 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 6;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case8()
        {
            // Assign
            int[] values = { 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 1;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case9()
        {
            // Assign
            int[] values = { 0, 0, 0, 0, 0 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 5;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case10()
        {
            // Assign
            int[] values = { 1, 0, 1, 0, 1, 0, 1 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 4;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case11()
        {
            // Assign
            int[] values = { 105, 104, 104, 103, 103, 102, 102, 101, 101, 100 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 6;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case12()
        {
            // Assign
            int[] values = { 105, 104, 103, 102, 101, 100, 99, 98, 97, 96, 95, 94, 93, 92, 91, 90 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 16;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case13()
        {
            // Assign
            var values = new List<int>
            {
                989949, 989948, 989947, 989946, 989945, 989944,
                989943, 989942, 989941, 989940, 989939, 989938,
                989937, 989936, 989935, 989934, 989933, 989932,
                989931, 989930, 989929, 989928, 989927, 989926,
                989925, 989924, 989923, 989922, 989921, 989920,
                989919, 989918, 989917, 989916, 989915, 989914,
                989913, 989912, 989911, 989910, 989909, 989908,
                989907, 989906, 989905, 989904, 989903, 989902,
                989901, 989900, 989899, 989898, 989897, 989896,
                989895, 989894, 989893, 989892, 989891, 989890,
                989889, 989888, 989887, 989886, 989885, 989884,
                989883, 989882, 989881, 989880, 989879, 989878,
                989877, 989876, 989875, 989874, 989873, 989872,
                989871, 989870, 989869, 989868, 989867, 989866,
                989865, 989864, 989863, 989862, 989861, 989860,
                989859, 989858, 989857, 989856, 989855, 989854,
                989853, 989852, 989851, 989850
            };

            for (int i = 0; i < 75; i++)
            {
                values.Add(0);
            }

            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values.ToArray());

            // Assert
            var expected = 175;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case50()
        {
            // Assign
            int[] values = Enumerable.Range(1, 10).ToArray();
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 10;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case60()
        {
            // Assign
            int[] values = { 0, 0, 1, 0, 0, 5, 6, 8, 11, 12, 13, 14, 15, 17, 20 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 13;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }

        [TestMethod]
        public void GetMaxStreak_Case70()
        {
            // Assign
            int[] values = { 0, 50, 3, 0, 46, 47, 7, 8, 14, 17, 23, 1, 2, 45 };
            var lngpok = new lngpok.Lngpok();

            // Act
            var result = lngpok.GetMaxStreak(values);

            // Assert
            var expected = 5;
            string errorMessage = $"Expected: {expected}, Actual: {result}";
            Assert.AreEqual(expected, result, errorMessage);
        }
    }
}
