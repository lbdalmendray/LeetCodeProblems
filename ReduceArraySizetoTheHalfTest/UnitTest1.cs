using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReduceArraySizetoTheHalf;

namespace ReduceArraySizetoTheHalfTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MinSetSize(new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 });
            Assert.AreEqual(result, 2);
        }
    }
}
