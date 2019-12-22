using System;
using MaximumCandiesYouCanGetfromBoxes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumCandiesYouCanGetfromBoxesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.MaxCandies(new int[] { 1, 0, 1, 0 }, new int[] { 7, 5, 4, 100 }, new int[][] { new int[] { }, new int[] { }, new int[] { 1 }, new int[] { } }, new int[][] { new int[] { 1 , 2 }, new int[] { 3 }, new int[] { }, new int[] { } }, new int[] { 0 });
            Assert.AreEqual(result, 16);
        }


        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.MaxCandies(new int[] { 1, 0, 0, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 1, 1 }, new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] { }, new int[] {  }, new int[] { }, new int[] { }, new int[] { } }, new int[][] { new int[] { 1, 2, 3, 4, 5 }, new int[] {  }, new int[] { }, new int[] { }, new int[] { }, new int[] { } }, new int[] { 0 });
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.MaxCandies(new int[] { 1, 1, 1 }, new int[] { 100, 1, 100 }, new int[][] { new int[] {  }, new int[] { 0,2 }, new int[] { } }, new int[][] { new int[] {  }, new int[] { }, new int[] { } }, new int[] { 1 });
            Assert.AreEqual(result, 1);
        }
    }
}
