using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberofClosedIslands;

namespace NumberofClosedIslandsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] input = new int[][] { new int[] { 1, 1, 1, 1, 1, 1, 1, 0 }, new int[] { 1, 0, 0, 0, 0, 1, 1, 0 }, new int[] { 1, 0, 1, 0, 1, 1, 1, 0 }, new int[] { 1, 0, 0, 0, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 0 } };
            Solution s = new Solution();
            Assert.AreEqual(s.ClosedIsland(input), 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
      
            0,0,1,0,0],[0,1,0,1,0],[0,1,1,1,0
            
    */

            int[][] input = new int[][] { new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 1, 0, 1, 0 }, new int[] { 0, 1, 1, 1, 0 } };
            Solution s = new Solution();
            Assert.AreEqual(s.ClosedIsland(input), 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
      
            [[1,1,1,1,1,1,1],
               [1,0,0,0,0,0,1],
               [1,0,1,1,1,0,1],
               [1,0,1,0,1,0,1],
               [1,0,1,1,1,0,1],
               [1,0,0,0,0,0,1],
               [1,1,1,1,1,1,1]]
            
    */

            int[][] input = new int[][] { new int[] { 1, 1, 1, 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 0, 0, 1 }, new int[] { 1, 0, 1, 1, 1, 0, 1 }
            , new int[] { 1,0,1,0,1,0,1 }
            , new int[] { 1,0,1,1,1,0,1 }
            , new int[] { 1,0,0,0,0,0,1 }
            , new int[] { 1,1,1,1,1,1,1 }};
            Solution s = new Solution();
            Assert.AreEqual(s.ClosedIsland(input), 2);
        }

    }
}
