using System;
using CheckIfItIsaStraightLine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIfItIsaStraightLineTest
{
    [TestClass]
    public class UnitTest1
    {
        // [[18,42],[1,-9],[6,6],[14,30],[-2,-18],[9,15],[-18,-66],[-7,-33],[7,9],[-19,-69],[10,18],[13,27],[-1,-15],[-13,-51],[-4,-24],[-5,-27],[-14,-54]]
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            // 
            var points = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 }, new int[] { 5, 6 }, new int[] { 6, 7 } };
            Assert.IsTrue(s.CheckStraightLine(points));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            // [1,1],[2,2],[3,4],[4,5],[5,6],[7,7]
            var points = new int[][] { new int[] { 18, 42 }, new int[] { 1, -9 }, new int[] { 6, 6 }, new int[] { 14, 30 }, new int[] { -2, -18 }, new int[] { 9, 15 }, new int[] { -18, -66 }, new int[] { -7, -33 }, new int[] { 7, 9 }, new int[] { -19, -69 }, new int[] { 10, 18 }, new int[] { 13, 27 }, new int[] { -1, -15}, new int[] { -13, -51 }, new int[] { -4, -24 }, new int[] { -5, -27 }, new int[] { -14, -54 } };
            Assert.IsTrue(s.CheckStraightLine(points));
        }
    }
}
