using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintHouseII;

namespace PaintHouseIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] input = new int[][]
             {
                new int[]{ 17, 2, 17 }
                ,new int[]{16, 16, 5 }
                ,new int[]{14, 3, 19 }
             };

            Solution s = new Solution();
            var result = s.MinCostII(input);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[][] input = new int[][]
             {
                new int[]{ 1, 5, 3 }
                ,new int[]{ 2, 9, 4 }
             };

            Solution s = new Solution();
            var result = s.MinCostII(input);
            Assert.AreEqual(result, 5);
        }
    }
}
