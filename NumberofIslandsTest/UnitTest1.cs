using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberofIslands;

namespace NumberofIslandsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            string[] grid = new string[]
            {
                "11110",
                "11010",
                "11000",
                "00000"
            };
            var result = s.NumIslands(grid.Select(e => e.ToArray()).ToArray());
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            string[] grid = new string[]
            {
                "11000",
                "11000",
                "00100",
                "00011"
            };
            var result = s.NumIslands(grid.Select(e => e.ToArray()).ToArray());
            Assert.AreEqual(result, 3);
        }
    }
}
