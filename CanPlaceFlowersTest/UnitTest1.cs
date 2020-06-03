using System;
using CanPlaceFlowers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanPlaceFlowersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 1 }, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 0, 0, 1 }, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 0, 0, 1 }, 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 0, 0, 1,0 }, 3);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 1, 0, 0, 0, 1, 0 , 0 }, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 5);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 0, 1 }, 2);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.CanPlaceFlowers(new int[] { 1, 0, 1, 0, 1, 0, 1 }, 0);
            Assert.IsTrue(result);
        }
    }
}
