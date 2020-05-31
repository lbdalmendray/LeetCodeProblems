using System;
using ConsecutiveNumbersSum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsecutiveNumbersSumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.ConsecutiveNumbersSum(5);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.ConsecutiveNumbersSum(9);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.ConsecutiveNumbersSum(15);
            Assert.AreEqual(result, 4);
        }
    }
}
