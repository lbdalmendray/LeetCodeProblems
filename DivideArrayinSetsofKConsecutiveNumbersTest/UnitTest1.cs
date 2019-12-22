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
    }
}
