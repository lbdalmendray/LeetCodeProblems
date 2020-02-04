using System;
using JumpGameV;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JumpGameVTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MaxJumps(new int[] { 6, 4, 14, 6, 8, 13, 9, 7, 10, 6, 12 }, 2);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MaxJumps(new int[] { 3, 3, 3, 3, 3 }, 3);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MaxJumps(new int[] { 7, 6, 5, 4, 3, 2, 1 }, 1);
            Assert.AreEqual(result, 7);
        }


        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MaxJumps(new int[] { 7, 1, 7, 1, 7, 1 }, 2);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MaxJumps(new int[] { 66 }, 1);
            Assert.AreEqual(result, 1);
        }
    }
}
