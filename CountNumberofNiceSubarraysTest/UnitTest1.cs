using System;
using CountNumberofNiceSubarrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountNumberofNiceSubarraysTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.NumberOfSubarrays(new int[] { 1, 1, 2, 1, 1 }, 3), 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.NumberOfSubarrays(new int[] { 2, 4, 6 }, 1), 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.NumberOfSubarrays(new int[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 }, 2), 16);
        }
    }
}
