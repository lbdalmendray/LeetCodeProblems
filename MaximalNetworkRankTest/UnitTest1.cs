using MaximalNetworkRank;

namespace MaximalNetworkRankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MaximalNetworkRank(4, [[0, 1], [0, 3], [1, 2], [1, 3]]);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MaximalNetworkRank(5, [[0, 1], [0, 3], [1, 2], [1, 3], [2, 3], [2, 4]]);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MaximalNetworkRank(8, [[0, 1], [1, 2], [2, 3], [2, 4], [5, 6], [5, 7]]);
            Assert.AreEqual(5, result);
        }
    }
}