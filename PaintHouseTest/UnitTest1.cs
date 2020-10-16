using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaintHouse;

namespace PaintHouseTest
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
            var result = s.MinCost(input);
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[][] input = new int[][]
            {
                
            };

            Solution s = new Solution();
            var result = s.MinCost(input);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[][] input = new int[][]
            {
                new int[]{ 7, 6, 2 }
            };

            Solution s = new Solution();
            var result = s.MinCost(input);
            Assert.AreEqual(result, 2);
        }
    }
}
