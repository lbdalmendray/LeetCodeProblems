using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumAbsoluteSumDifference;

namespace MinimumAbsoluteSumDifferenceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nums1 = new int[] { 1, 7, 5 };
            var nums2 = new int[] { 2, 3, 5 };
            Solution s = new Solution();
            var result = s.MinAbsoluteSumDiff(nums1, nums2);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var nums1 = new int[] { 2, 4, 6, 8, 10 };
            var nums2 = new int[] { 2, 4, 6, 8, 10 };
            Solution s = new Solution();
            var result = s.MinAbsoluteSumDiff(nums1, nums2);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var nums1 = new int[] { 1, 10, 4, 4, 2, 7 };
            var nums2 = new int[] { 9, 3, 5, 1, 7, 4 };
            Solution s = new Solution();
            var result = s.MinAbsoluteSumDiff(nums1, nums2);
            Assert.AreEqual(result, 20);
        }
    }
}
