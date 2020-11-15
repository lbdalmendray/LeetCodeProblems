using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlidingWindowMaximum;

namespace SlidingWindowMaximumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MaxSlidingWindow(nums: new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, k: 3);
            CollectionAssert.AreEquivalent(result, new int[] { 3, 3, 5, 5, 6, 7 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MaxSlidingWindow(nums: new int[] { 1 }, k: 1);
            CollectionAssert.AreEquivalent(result, new int[] { 1 });
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MaxSlidingWindow(nums: new int[] { 1, -1 }, k: 1);
            CollectionAssert.AreEquivalent(result, new int[] { 1, -1 });
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MaxSlidingWindow(nums: new int[] { 9, 11 }, k: 2);
            CollectionAssert.AreEquivalent(result, new int[] { 11 });
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MaxSlidingWindow(nums: new int[] { 4, -2 }, k: 2);
            CollectionAssert.AreEquivalent(result, new int[] { 4 });
        }

    }
}
