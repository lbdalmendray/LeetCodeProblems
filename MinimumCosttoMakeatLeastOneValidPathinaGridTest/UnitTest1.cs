using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumCosttoMakeatLeastOneValidPathinaGrid;

namespace MinimumCosttoMakeatLeastOneValidPathinaGridTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: grid = [[1,1,1,1],[2,2,2,2],[1,1,1,1],[2,2,2,2]]
Output: 3
             */

            var grid = new int[][] {
                new int[]{1, 1, 1, 1 },
                new int[]{2, 2, 2, 2 },
                new int[]{1, 1, 1, 1 },
                new int[]{2, 2, 2, 2 }
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 3);
        }


        [TestMethod]
        public void TestMethod2()
        {
            var grid = new int[][] {
                new int[]{1},
                new int[]{2}
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: grid = [[1,1],[2,2]]
Output: 1
             */

            var grid = new int[][] {
                new int[]{1,1},
                new int[]{2,2}
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            /*
             Input: grid = [[1,1,3],[3,2,2],[1,1,4]]
Output: 0
             */

            var grid = new int[][] {
                new int[]{1,1,3},
                new int[]{ 3, 2, 2 },
                new int[]{ 1, 1, 4 }
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 0);
        }


        [TestMethod]
        public void TestMethod5()
        {
            /*
             Input: grid = [[1,2],[4,3]]
Output: 1
             */

            var grid = new int[][] {
                new int[]{1,2},
                new int[]{ 4, 3 }
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            /*
             Input: grid = [[2,2,2],[2,2,2]]
Output: 3
             */

            var grid = new int[][] {
                new int[]{2,2,2},
                new int[]{ 2, 2, 2 }
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 3);
        }


        [TestMethod]
        public void TestMethod7()
        {
            /*
             Input: grid = [[4]]
Output: 0
             */

            var grid = new int[][] {
                new int[]{4}
            };

            Solution s = new Solution();
            var result = s.MinCost(grid);
            Assert.AreEqual(result, 0);
        }
    }
}
