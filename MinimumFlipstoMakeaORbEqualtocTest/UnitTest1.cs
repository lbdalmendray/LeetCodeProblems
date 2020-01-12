using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumFlipstoMakeaORbEqualtoc;

namespace MinimumFlipstoMakeaORbEqualtocTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MinFlips(2, 6, 5);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MinFlips(4, 2, 7);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MinFlips(1, 2, 3);
            Assert.AreEqual(result, 0);
        }


        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MinFlips(8, 3, 5);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MinFlips(5, 2, 8);
            Assert.AreEqual(result, 4);
        }
    }
}
