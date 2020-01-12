using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumDistancetoTypeaWordUsingTwoFingers;

namespace MinimumDistancetoTypeaWordUsingTwoFingersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MinimumDistance("CAKE");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MinimumDistance("HAPPY");
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MinimumDistance("NEW");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.MinimumDistance("YEAR");
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.MinimumDistance("AB");
            Assert.AreEqual(result, 0);
        }
    }
}
