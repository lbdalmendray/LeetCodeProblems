using System;
using AsteroidCollision;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsteroidCollisionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { 5, 10, -5 });
            CollectionAssert.AreEquivalent(result, new[] { 5, 10 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { 8, -8 });
            CollectionAssert.AreEquivalent(result, new int[] { });
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { 10, 2, -5 });
            CollectionAssert.AreEquivalent(result, new int[] { 10 });
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { -2, -1, 1, 2 });
            CollectionAssert.AreEquivalent(result, new int[] { -2, -1, 1, 2 });
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { 0,0,0 });
            CollectionAssert.AreEquivalent(result, new int[] { 0,0,0 });
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { 0, 0, 0 , -2 , 3 , -5});
            CollectionAssert.AreEquivalent(result, new int[] { -2, -5 });
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.AsteroidCollision(new[] { -2, 0, 10, 0, 0, -2, 3, -5 });
            CollectionAssert.AreEquivalent(result, new int[] { -2, 0, 10 });
        }
    }

}
