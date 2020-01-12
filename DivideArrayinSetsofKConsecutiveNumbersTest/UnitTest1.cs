using System;
using DivideArrayinSetsofKConsecutiveNumbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DivideArrayinSetsofKConsecutiveNumbersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 1, 2, 3, 3, 4, 4, 5, 6 }, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 11 }, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 3, 3, 2, 2, 1, 1 }, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 1, 2, 3, 4 }, 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 12 }, 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 3, 2, 1, 2, 3, 4, 3, 4, 5, 9, 10, 12 }, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.IsPossibleDivide(new int[] { 16, 5, 15, 15, 20, 16, 20, 14, 21, 20, 19, 20, 12, 17, 13, 15, 11, 17, 18, 18, 11, 13, 13, 14, 14, 9, 20, 18, 10, 4, 4, 6, 15, 19, 8, 15, 7, 17, 15, 9, 24, 2, 23, 22, 26, 8, 21, 22, 14, 13, 16, 2, 25, 23, 17, 19, 17, 3, 22, 23, 19, 12, 21, 12, 16, 27, 28, 10, 13, 8, 24, 3, 22, 6, 10, 9, 14, 7, 11, 22, 11, 5, 16, 19, 21, 2, 8, 24, 16, 21, 7, 29, 18, 9, 10, 18, 6, 17, 21, 20 }, 10);
            Assert.IsFalse(result);
        }
    }
}
