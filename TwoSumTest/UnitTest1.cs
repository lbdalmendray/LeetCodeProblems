using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwoSumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            //CollectionAssert.AreEqual(solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9), new int[] { 0, 1 });
            //CollectionAssert.AreEqual(solution.TwoSum(new int[] { 2, 5,5,11 }, 10), new int[] { 1,2 });
            CollectionAssert.AreEqual(solution.TwoSum(new int[] { 3,2,3 }, 6), new int[] { 0,2 });
        }
    }
}
