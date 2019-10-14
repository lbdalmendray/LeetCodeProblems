using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitaStringinBalancedStrings;

namespace SplitaStringinBalancedStringsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.BalancedStringSplit("RLRRLLRLRL"), 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.BalancedStringSplit("RLLLLRRRLR"), 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.BalancedStringSplit("LLLLRRRR"), 1);
        }
    }
}
