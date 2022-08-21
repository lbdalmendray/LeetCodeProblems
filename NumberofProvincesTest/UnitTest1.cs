using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberofProvinces;
using System;

namespace NumberofProvincesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] input = GenerateLine();
            Solution solution = new Solution();
            int result = solution.FindCircleNum(input);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[][] input = new int[][]
            {
                 new int[]{1, 1, 0 }
                ,new int[]{1, 1, 0 }
                ,new int[]{0, 0, 1 }
            };
            Solution solution = new Solution();
            int result = solution.FindCircleNum(input);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[][] input = new int[][]
            {
                 new int[]{1, 0, 0 }
                ,new int[]{0, 1, 0 }
                ,new int[]{0, 0, 1 }
            };
            Solution solution = new Solution();
            int result = solution.FindCircleNum(input);
            Assert.AreEqual(result, 3);
        }

        private int[][] GenerateLine()
        {
            int[][] result = new int[200][];

            for (int i = 0; i < 200; i++)
            {
                result[i] = new int[200];
            }

            for (int i = 0; i < 199; i++)
            {
                result[i][i+1] = 1;
                result[i+1][i] = 1;
            }

            return result;
        }
    }
}