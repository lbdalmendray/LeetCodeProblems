using System;
using System.Linq;
using MaximumNumberofOccurrencesofaSubstring;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumNumberofOccurrencesofaSubstringTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MaxFreq("aababcaab", 2, 3, 4);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MaxFreq("aaaa", 1, 3, 3);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MaxFreq("aaaa", 2, 2, 3);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MaxFreq("abcde", 2, 3, 3);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MaxFreq(new string(Enumerable.Repeat('a', 100000).ToArray()), 26, 1, 26);
            Assert.AreEqual(result, 100000);
        }
    }
}
