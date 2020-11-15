using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseWordsinaString;

namespace ReverseWordsinaStringTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.ReverseWords("the sky is blue");
            Assert.AreEqual(result, "blue is sky the");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.ReverseWords("  hello world!  ");
            Assert.AreEqual(result, "world! hello");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.ReverseWords("  hello world!  ");
            Assert.AreEqual(result, "world! hello");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.ReverseWords("a good   example");
            Assert.AreEqual(result, "example good a");
        }
    }
}
