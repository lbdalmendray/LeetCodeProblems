using CountCollisionsonaRoad;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountCollisionsonaRoadTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.CountCollisions("RLRSLL");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.CountCollisions("LLRR");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.CountCollisions("SSRSSRLLRSLLRSRSSRLRRRRLLRRLSSRR");
            Assert.AreEqual(result, 20);
        }
    }
}
