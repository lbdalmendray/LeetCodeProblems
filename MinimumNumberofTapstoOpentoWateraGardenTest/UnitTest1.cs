using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumNumberofTapstoOpentoWateraGarden;

namespace MinimumNumberofTapstoOpentoWateraGardenTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // n = 5, ranges = [3,4,1,1,0,0]
            Solution s = new Solution();
            var result = s.MinTaps(5, new int[] { 3, 4, 1, 1, 0, 0 });
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // n = 3, ranges = [0,0,0,0]
            Solution s = new Solution();
            var result = s.MinTaps(3, new int[] { 0, 0, 0, 0 });
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // n = 3, ranges = [0,0,0,0]
            Solution s = new Solution();
            var result = s.MinTaps(7, new int[] { 1, 2, 1, 0, 2, 1, 0, 1 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // n = 3, ranges = [0,0,0,0]
            Solution s = new Solution();
            var result = s.MinTaps(8, new int[] { 4, 0, 0, 0, 0, 0, 0, 0, 4 });
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod5()
        {
            // n = 3, ranges = [0,0,0,0]
            Solution s = new Solution();
            var result = s.MinTaps(8, new int[] { 4, 0, 0, 0, 4, 0, 0, 0, 4 });
            Assert.AreEqual(result, 1);
        }
    }
}
