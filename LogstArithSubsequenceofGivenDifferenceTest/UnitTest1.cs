using System;
using LongestArithmeticSubsequenceofGivenDifference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogstArithSubsequenceofGivenDifferenceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             [1,3,5,7]
1
            */
            Solution s = new Solution();
            Assert.IsTrue(s.LongestSubsequence(new int[] { 1, 3, 5, 7 }, 1) == 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             [1,2,3,4]
1
            */
            Solution s = new Solution();
            Assert.IsTrue(s.LongestSubsequence(new int[] { 1, 2, 3, 4 }, 1) == 4);
        }
    }
}
