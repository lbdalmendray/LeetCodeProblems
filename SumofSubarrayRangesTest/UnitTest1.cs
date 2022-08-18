using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumofSubarrayRanges;

namespace SumofSubarrayRangesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.SubArrayRanges(new int[] { 1, 2, 3 });
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.SubArrayRanges(new int[] { 1, 3, 3 });
            Assert.AreEqual(result, 4);
        }
    }
}