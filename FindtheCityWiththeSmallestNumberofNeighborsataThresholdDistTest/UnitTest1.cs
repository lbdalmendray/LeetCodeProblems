using System;
using FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = new int[][] {
                new int[] { 0, 1, 3 }
                , new int[] { 1, 2, 1 }
                , new int[] { 1, 3, 4 }
                , new int[] { 2, 3, 1 } };

            Solution s = new Solution();
            var result = s.FindTheCity(4, input, 4);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: n = 5, edges = [[0,1,2],[0,4,8],[1,2,3],[1,4,2],[2,3,1],[3,4,1]], distanceThreshold = 2
Output: 0
             */

            var input = new int[][] {
                new int[] { 0, 1, 2 }
                , new int[] { 0, 4, 8 }
                , new int[] { 1, 2, 3 }
                , new int[] { 1, 4, 2 }
                , new int[] { 2,3,1 }
                , new int[] { 3, 4, 1 }
            };

            Solution s = new Solution();
            var result = s.FindTheCity(5, input, 2);
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: n = 5, edges = [[0,1,2],[0,4,8],[1,2,3],[1,4,2],[2,3,1],[3,4,1]], distanceThreshold = 2
Output: 0
             */

            var input = new int[][] {
                new int[]{0,1,2}
            };

            Solution s = new Solution();
            var result = s.FindTheCity(2, input, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = new int[][] {
                new int[]{0,1,1},
                new int[]{0,2,1},
                new int[]{1,2,2},
            };

            Solution s = new Solution();
            var result = s.FindTheCity(3, input, 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = new int[][] {
                new int[]{0,1,1},
                new int[]{0,2,1},
            };

            Solution s = new Solution();
            var result = s.FindTheCity(3, input, 1);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = new int[][] {
                new int[]{0,1,1},
                new int[]{0,2,1},
                new int[]{1,2,1},
            };

            Solution s = new Solution();
            var result = s.FindTheCity(3, input, 1);
            Assert.AreEqual(2, result);
        }
    }
}
