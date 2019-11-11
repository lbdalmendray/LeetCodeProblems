using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumSwapstoMakeStringsEqual;

namespace MinimumSwapstoMakeStringsEqualTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinimumSwap("xx", "yy"), 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinimumSwap("xy", "yx"), 2);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinimumSwap("xx", "xy"), -1);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinimumSwap("xy", "yx"), 2);
        }
    }
}
