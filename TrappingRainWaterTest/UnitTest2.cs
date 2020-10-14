using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrappingRainWater;

namespace TrappingRainWaterTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution2 s = new Solution2();
            int result = s.Trap(new int[] { 0,1,0,1,2});
            Assert.AreEqual(result, 1); //[4,2,3]
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution2 s = new Solution2();
            int result = s.Trap(new int[] { 0, 1, 0, 2});
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution2 s = new Solution2();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3 });
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution2 s = new Solution2();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3 });
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution2 s = new Solution2();
            int result = s.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution2 s = new Solution2();
            int result = s.Trap(new int[] { 4, 2, 3 });
            Assert.AreEqual(result, 1); 
        }

        [TestMethod]
        public void CalculateWaterZone1()
        {
            Solution2 s = new Solution2();
            int result = s.CalculateWater(new int[] { 1, 0, 1 }, 0, 2);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CalculateWaterZone2()
        {
            Solution2 s = new Solution2();
            int result = s.CalculateWater(new int[] { 5,1, 2, 8 }, 0, 3);
            Assert.AreEqual(result, 5-1 + 5-2);
        }

        [TestMethod]
        public void CalculateFindMaxPikeas1()
        {
            Solution2 s = new Solution2();
            var result = s.FindMaxPeaks(new int[] { 1, 0, 1 });

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Length , 2);
            Assert.AreEqual(result[0][0] , 0);
            Assert.AreEqual(result[0][1] , 0);

            Assert.AreEqual(result[1].Length , 2);
            Assert.AreEqual(result[1][0], 2);
            Assert.AreEqual(result[1][1], 2);
        }

        [TestMethod]
        public void CalculateFindMaxPikeas2()
        {
            Solution2 s = new Solution2();
            var result = s.FindMaxPeaks(new int[] { 0, 1, 0, 2 });
            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Length, 2);
            Assert.AreEqual(result[0][0], 1);
            Assert.AreEqual(result[0][1], 1);
            Assert.AreEqual(result[1].Length, 2);
            Assert.AreEqual(result[1][0], 3);
            Assert.AreEqual(result[1][1], 3);
        }

        [TestMethod]
        public void CalculateFindMaxPikeas3()
        {
            Solution2 s = new Solution2();
            var result = s.FindMaxPeaks(new int[] { 0, 1, 0, 2, 1, 0, 1, 3 });
            Assert.AreEqual(result.Length, 3);

            Assert.AreEqual(result[0].Length, 2);
            Assert.AreEqual(result[0][0], 1);
            Assert.AreEqual(result[0][1], 1);

            Assert.AreEqual(result[1].Length, 2);
            Assert.AreEqual(result[1][0], 3);
            Assert.AreEqual(result[1][1], 3);

            Assert.AreEqual(result[2].Length, 2);
            Assert.AreEqual(result[2][0], 7);
            Assert.AreEqual(result[2][1], 7);
        }


        [TestMethod]
        public void CalculateFindMaxPikeas4()
        {
            Solution2 s = new Solution2();
            var result = s.FindMaxPeaks(new int[] { 0, 1,1,0, 0, 2,3,4,4,4, 1, 0, 1,2,2,3,3 });
            Assert.AreEqual(result.Length, 3);

            Assert.AreEqual(result[0].Length, 2);
            Assert.AreEqual(result[0][0], 1);
            Assert.AreEqual(result[0][1], 2);

            Assert.AreEqual(result[1].Length, 2);
            Assert.AreEqual(result[1][0], 7);
            Assert.AreEqual(result[1][1], 9);

            Assert.AreEqual(result[2].Length, 2);
            Assert.AreEqual(result[2][0], 15);
            Assert.AreEqual(result[2][1], 16);
        }
    }
}
