using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestWordDistance;

namespace ShortestWordDistanceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.ShortestDistance(new string[] { "practice", "makes", "perfect", "coding", "makes" }, "coding", "practice");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.ShortestDistance(new string[] { "practice", "makes", "perfect", "coding", "makes" }, "makes", "coding");
            Assert.AreEqual(result, 1);
        }
    }
}
