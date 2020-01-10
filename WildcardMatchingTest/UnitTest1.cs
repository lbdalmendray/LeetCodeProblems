using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WildcardMatching;

namespace WildcardMatchingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.IsMatch("aa", "a");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.IsMatch("", "");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.IsMatch("", "*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.IsMatch("", "?");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "*b*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod51()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "*?*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "b*b*");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod61()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "?*b*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "*b*b*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "*?*?*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "a???*");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abababbb", "?c?*");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.IsMatch("aaaaaaaabc", "********b");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.IsMatch("aaaaaaaabc", "*b");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            var result = s.IsMatch("abc", "*b");
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestMethod14()
        {
           // "aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba"
           //"a*******b"
            Solution s = new Solution();
            var result = s.IsMatch("aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba", "a*b");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod15()
        {
            // "aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba"
            //"a*******b"
            Solution s = new Solution();
            var result = s.IsMatch("aaabbbaabaaaaababaabaaabbabbbbbbbbaabababbabbbaaaaba", "a*******b");
            Assert.IsFalse(result);
        }
    }
}
