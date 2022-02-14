using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimumDominoRotationsForEqualRow;

namespace MinimumDominoRotationsForEqualRowTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            int result = s.MinDominoRotations(
                new int[] { 2, 1, 2, 4, 2, 2 }
                , new int[] { 5, 2, 6, 2, 3, 2 }
                );

            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            int result = s.MinDominoRotations(
                new int[] { 3, 5, 1, 2, 3 }
                , new int[] { 3, 6, 3, 3, 4 }
                );

            Assert.AreEqual(result, -1);
        }
    }
}
