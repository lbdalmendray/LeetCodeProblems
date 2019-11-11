using System;
using CheckIfItIsaGoodArray;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIfItIsaGoodArrayTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.IsTrue(s.IsGoodArray(new int[] { 12, 5, 7, 23 }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.IsTrue(s.IsGoodArray(new int[] { 29, 6, 10 }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.IsFalse(s.IsGoodArray(new int[] { 3, 6 }));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            Assert.IsFalse(s.IsGoodArray(new int[] { 4,8,2,16,22 }));
        }
    }
}
