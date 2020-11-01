using FurthestBuildingYouCanReach;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FurthestBuildingYouCanReachTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.FurthestBuilding(new int[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.FurthestBuilding(new int[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.FurthestBuilding(new int[] { 14, 3, 19, 3 }, 17, 0);
            Assert.AreEqual(result, 3);
        }
    }
}
