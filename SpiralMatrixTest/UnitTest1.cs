using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiralMatrix;

namespace SpiralMatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] input = new int[][]
            {
                new int[]{1, 2, 3 },
                new int[]{4, 5, 6},
                new int[]{7, 8, 9}
            };

            Solution s = new Solution();
            var result =  s.SpiralOrder(input);
            int[] expected = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[][] input = new int[][]
            {
                new int[]{1, 2, 3, 4 },
                new int[]{5, 6, 7, 8},
                new int[]{ 9, 10, 11, 12 }
            };

            Solution s = new Solution();
            var result = s.SpiralOrder(input);
            int[] expected = new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 };
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[][] input = new int[][]
            {
                new int[]{8}
            };

            Solution s = new Solution();
            var result = s.SpiralOrder(input);
            int[] expected = new int[] { 8 };
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[][] input = new int[][]
            {
                new int[]{}
            };

            Solution s = new Solution();
            var result = s.SpiralOrder(input);
            int[] expected = new int[] { };
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[][] input = new int[][]
            {
                new int[]{ 1, 2 , 3 ,4 ,5 , 6 }
            };

            Solution s = new Solution();
            var result = s.SpiralOrder(input);
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6  };
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod6()
        {
            int[][] input = new int[][]
            {
                new int[]{1} ,
                new int[]{2 },
                new int[]{3 } ,
                new int[]{4 } ,
                new int[]{5 } ,
                new int[]{6 }
            };

            Solution s = new Solution();
            var result = s.SpiralOrder(input);
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }

        [TestMethod]
        public void TestMethod7()
        {
            int[][] input = new int[][]
            {
                new int[]{1,    2,  3   ,   4   ,   5   ,   6   ,   7 },
                new int[]{24,   25, 26  ,   27  ,   28  ,   29  ,   8 },
                new int[]{23,   40, 41  ,   42  ,   43  ,   30  ,   9 },
                new int[]{22,   39, 48  ,   49  ,   44  ,   31  ,   10 },
                new int[]{21,   38, 47  ,   46  ,   45  ,   32  ,   11 },
                new int[]{20,   37, 36  ,   35  ,   34  ,   33  ,   12 },
                new int[]{19,   18, 17  ,   16  ,   15  ,   14  ,   13 },
            };

            Solution s = new Solution();
            var result = s.SpiralOrder(input);
            int[] expected = Enumerable.Range(1,49).ToArray();
            CollectionAssert.AreEquivalent(result.ToList(), expected.ToList());
        }
    }
}
