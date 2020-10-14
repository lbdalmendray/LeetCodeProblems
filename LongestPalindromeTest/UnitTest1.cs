using System;
using LongestPalindrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestPalindromeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.LongestPalindrome("babad");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.LongestPalindrome("abccccdd");
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.LongestPalindrome("a");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.LongestPalindrome("ab");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.LongestPalindrome("abb");
            Assert.AreEqual(result, 3);
        }
    }
}
