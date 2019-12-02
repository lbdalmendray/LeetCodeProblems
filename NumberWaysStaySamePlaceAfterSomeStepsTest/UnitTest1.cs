using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberWaystoStayintheSamePlaceAfterSomeSteps;

namespace NumberWaysStaySamePlaceAfterSomeStepsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.NumWays(3, 2);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.NumWays(2, 4);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.NumWays(4, 2);
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.NumWays(500, 1000000);
            Assert.AreEqual(result, 374847123);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.NumWays(355, 10000);
            Assert.AreEqual(result, 557476382);
        }
    }
}
