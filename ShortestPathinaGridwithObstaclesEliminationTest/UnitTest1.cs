using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestPathinaGridwithObstaclesElimination;
using Utils;

namespace ShortestPathinaGridwithObstaclesEliminationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,0,0],[1, 1, 0],[0, 0, 0], [0, 1, 1], [0, 0, 0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 1);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,1,1],[1, 1, 1],[1, 0, 0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 1);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,1,1],[1, 1, 1],[0, 0, 0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 1);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var origInput = Utils.Utils.ParseArrayArrayInteger("[[0,1,1],[1, 1, 1],[0, 0, 0]]");
            var input = ConvertToLength(origInput,40);
            Solution s = new Solution();
            var result = s.ShortestPath(input, 1);
            Assert.AreEqual(result, 4 + 40- origInput.Length + 40- origInput[0].Length);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var origInput = Utils.Utils.ParseArrayArrayInteger("[[0,1,1],[1, 1, 1],[1, 0, 0]]");
            var input = ConvertToLength(origInput, 40);
            Solution s = new Solution();
            var result = s.ShortestPath(input, 1);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var origInput = Utils.Utils.ParseArrayArrayInteger("[[0,0,0],[1, 1, 0],[0, 0, 0], [0, 1, 1], [0, 0, 0]]");
            var input = ConvertToLength(origInput, 40);
            Solution s = new Solution();
            var result = s.ShortestPath(input, 1);
            Assert.AreEqual(result, 6 + 40 - origInput.Length + 40 - origInput[0].Length);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 0);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 0);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod9()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,1,0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 0);
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod10()
        {
            var input = Utils.Utils.ParseArrayArrayInteger("[[0,1,1],[1, 1, 1],[1, 1, 1], [1, 1, 1], [1, 1, 0]]");
            Solution s = new Solution();
            var result = s.ShortestPath(input, 5);
            Assert.AreEqual(result, 6);
        }

        int [][] ConvertToLength(int[][] input , int length)
        {
            int[][] result = new int[length][];
            for (int i = 0; i < length; i++)
            {
                result[i] = new int[length];
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    result[i][j] = input[i][j];
                }
            }

            return result;
        }
    }
}
