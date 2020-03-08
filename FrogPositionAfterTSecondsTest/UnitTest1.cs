using System;
using FrogPositionAfterTSeconds;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogPositionAfterTSecondsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 2, target = 4
            Solution s = new Solution();
            var result = s.FrogPosition(7, new int[][] { new int[] { 1, 2}, new int[] { 1, 3}, new int[] { 1, 7}, new int[] { 2, 4}, new int[] { 2, 6}, new int[] { 3, 5 } }, 2, 4);
            Assert.AreEqual(result, 0.16666666666666666);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 1, target = 7
            Solution s = new Solution();
            var result = s.FrogPosition(7, new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } }, 1, 7);
            Assert.AreEqual(result, 0.3333333333333333);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 20, target = 6
            Solution s = new Solution();
            var result = s.FrogPosition(7, new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } }, 20, 6);
            Assert.AreEqual(result, 0.16666666666666666);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // n = 3, edges =  [[2,1],[3,2]] , t =  1 , target = 2
            Solution s = new Solution();
            var result = s.FrogPosition(3, new int[][] { new int[] { 2,1 }, new int[] { 3,2 } }, 1, 2);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // n = 3, edges =  [[2,1],[3,2]] , t =  1 , target = 2
            Solution s = new Solution();
            var result = s.FrogPosition(8 , new int[][] { new int[] { 2, 1 }, new int[] { 3, 2 }, new int[] { 4, 1 }
            , new int[] { 5, 1 }
            , new int[] { 6, 4 }
            , new int[] { 7, 1 }
            , new int[] { 8, 7 }
            }, 7, 7);
            Assert.AreEqual(result, 0.0); 
        }

        /*
      
        8
[[2,1],[3,2],[4,1],[5,1],[6,4],[7,1],[8,7]]
7
7
        
    */

    }
}
