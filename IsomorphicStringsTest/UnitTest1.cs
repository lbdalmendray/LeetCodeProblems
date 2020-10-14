using System;
using IsomorphicStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsomorphicStringsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.IsIsomorphic("egg", "add");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.IsIsomorphic("foo", "bar");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.IsIsomorphic("paper", "title");
            Assert.IsTrue(result);
        }
    }
}
