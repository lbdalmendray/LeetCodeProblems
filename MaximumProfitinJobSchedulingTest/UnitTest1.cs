using System;
using System.Linq;
using MaximumProfitinJobScheduling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumProfitinJobSchedulingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual( s.JobScheduling(new int[] { 1, 2, 3, 3 }, new int[] { 3, 4, 5, 6 }, new int[] { 50, 10, 40, 70 }),120);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.JobScheduling(new int[] { 1, 2, 3, 4, 6 }, new int[] { 3, 5, 10, 6, 9 }, new int[] { 20, 20, 100, 70, 60 }), 150);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.JobScheduling(new int[] { 1, 1, 1 }, new int[] { 2, 3, 4 }, new int[] { 5, 6, 4 }), 6);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var starElements = Enumerable.Range(0, 4000).ToArray();
            var endElements = Enumerable.Range(1, 4001).ToArray();
            var profitElements = Enumerable.Repeat(1, 4000).ToArray();
            Assert.AreEqual(s.JobScheduling(starElements, endElements, profitElements), 4000);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var starElements = Enumerable.Range(0, 1).ToArray();
            var endElements = Enumerable.Range(1, 2).ToArray();
            var profitElements = Enumerable.Repeat(1, 1).ToArray();
            Assert.AreEqual(s.JobScheduling(starElements, endElements, profitElements), 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var starElements = new int[]{ 1,3,3,3,5,5,13,5 };
            var endElements = new int[] { 17, 14, 8, 11, 14, 7, 17, 9 };
            var profitElements = new int[] { 9, 3, 7, 18, 2, 17, 4, 6 };
            Assert.AreEqual(s.JobScheduling(starElements, endElements, profitElements), 22);
        }

    }
}
