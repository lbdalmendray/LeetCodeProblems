using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromePartitioningIII;

namespace PalindromePartitioningIIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.PalindromePartition("abc", 2);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.PalindromePartition("a", 1);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            for (int i = 1; i <= 100 ; i++)
            {
                var result = s.PalindromePartition(new string(Enumerable.Repeat('a', i).ToArray()), i);
                Assert.AreEqual(result, 0);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.PalindromePartition("aabbc", 3);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.PalindromePartition("leetcode", 8);
            Assert.AreEqual(result, 0);
        }
    }
}
