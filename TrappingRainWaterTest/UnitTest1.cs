using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrappingRainWater;

namespace TrappingRainWaterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 0,1,0,1,2});
            Assert.AreEqual(result, 1); //[4,2,3]
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 0, 1, 0, 2});
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3 });
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3 });
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            int result = s.Trap(new int[] { 4, 2, 3 });
            Assert.AreEqual(result, 1); 
        }

        [TestMethod]
        public void CalculateWaterZone1()
        {
            Solution s = new Solution();
            int result = s.CalculateWater(new int[] { 1, 0, 1 }, 0, 2);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CalculateWaterZone2()
        {
            Solution s = new Solution();
            int result = s.CalculateWater(new int[] { 5,1, 2, 8 }, 0, 3);
            Assert.AreEqual(result, 5*4 - (5+1+2+5));
        }
    }
}
