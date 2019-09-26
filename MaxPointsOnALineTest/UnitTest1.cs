using System;
using MaxPointsOnALine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxPointsOnALineTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 1 ,1 } , new int[] { 2,2 } , new int[] { 3,3 } };
            Assert.IsTrue(solution.MaxPoints(points) == 3 );
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 1, 1 }, new int[] { 3, 2 }, new int[] { 5, 3 }, new int[] { 4, 1 }, new int[] { 2, 3 }, new int[] { 1, 4 } };
            Assert.IsTrue(solution.MaxPoints(points) == 4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 1, 1 } , new int[] { 1, 1 } };
            Assert.IsTrue(solution.MaxPoints(points) == 2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 1, 2 }, new int[] { 4, 2 } , new int[] { 4, 2 }, new int[] { 7, 2 } };
            Assert.IsTrue(solution.MaxPoints(points) == 4);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] {  };
            Assert.IsTrue(solution.MaxPoints(points) == 0);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 } };
            Assert.IsTrue(solution.MaxPoints(points) == 2);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 0, 0 }, new int[] { -1 , -1 }, new int[] { 2, 2 } };
            Assert.IsTrue(solution.MaxPoints(points) == 3);
        }

        // [[0,0],[94911151,94911150],[94911152,94911151]]

        [TestMethod]
        public void TestMethod8()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 0, 0 }, new int[] { 94911151, 94911150 }, new int[] { 94911152, 94911151 } };
            Assert.IsTrue(solution.MaxPoints(points) == 2);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution solution = new Solution();
            int[][] points = new int[][] { new int[] { 0, 0 }, new int[] { 0,0 }, new int[] { 1,2 } };
            Assert.IsTrue(solution.MaxPoints(points) == 3);
        }
    }
}
