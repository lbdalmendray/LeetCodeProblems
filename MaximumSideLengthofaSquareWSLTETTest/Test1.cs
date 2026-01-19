using MaximumSideLengthofaSquareWSLTET;

namespace MaximumSideLengthofaSquareWSLTETTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result =solution.MaxSideLength([[1, 1, 3, 2, 4, 3, 2], [1, 1, 3, 2, 4, 3, 2], [1, 1, 3, 2, 4, 3, 2]]
            , 4);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MaxSideLength([[2, 2, 2, 2, 2], [2, 2, 2, 2, 2], [2, 2, 2, 2, 2], [2, 2, 2, 2, 2], [2, 2, 2, 2, 2]]
            , 1);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MaxSideLength([[2, 2, 1000, 1000, 1000],[2, 3, 1000, 1000, 1000],[2000, 2000, 1000, 1000, 1000],[2000, 2000, 1000, 1000, 1000],[2000, 2000, 1000, 1000, 1000]]
            , 9);

            Assert.AreEqual(2, result);
        }
    }
}
