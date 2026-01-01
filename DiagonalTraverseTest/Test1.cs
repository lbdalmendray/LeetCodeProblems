using DiagonalTraverse;

namespace DiagonalTraverseTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.FindDiagonalOrder([[1], [2], [3], [4]]);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2, 3, 4 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.FindDiagonalOrder([[1,2,3,4,5]]);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2, 3, 4,5 });
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.FindDiagonalOrder([[1,2,3], [4,5,6], [7,8,9]]);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2, 4, 7,5,3,6,8,9 });
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.FindDiagonalOrder([[1, 2], [3,4]]);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2, 3, 4});
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.FindDiagonalOrder([[1, 2], [3, 5], [4,6]]);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2, 3, 4 , 5, 6});
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            var result = solution.FindDiagonalOrder([[1, 2, 5, 6], [3, 4, 7, 8]]);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        }
    }
}
