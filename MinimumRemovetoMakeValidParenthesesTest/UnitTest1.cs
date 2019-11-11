using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumRemovetoMakeValidParentheses;

namespace MinimumRemovetoMakeValidParenthesesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual( s.MinRemoveToMakeValid("lee(t(c)o)de)") , "lee(t(c)o)de");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinRemoveToMakeValid("a)b(c)d"), "ab(c)d");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinRemoveToMakeValid("))(("), "");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MinRemoveToMakeValid("(a(b(c)d)"), "a(b(c)d)");
        }
    }
}
