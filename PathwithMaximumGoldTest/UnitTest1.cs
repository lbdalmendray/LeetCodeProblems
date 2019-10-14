using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathwithMaximumGold;

namespace PathwithMaximumGoldTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             grid = [[0,6,0],[5,8,7],[0,9,0]]
             */
            var grid = new int[3][] { new int[]{ 0, 6, 0 }, new int[] { 5, 8, 7 }, new int[] { 0, 9, 0 } };
            Solution sol = new Solution();
            Assert.AreEqual(sol.GetMaximumGold(grid), 24);
        }
    }
}
