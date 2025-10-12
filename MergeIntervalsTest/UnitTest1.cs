using MergeIntervals;

namespace MergeIntervalsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.Merge([[1, 3], [2, 6], [8, 10], [15, 18]]);

            int[][] expecteArray = [[1, 6], [8, 10], [15, 18]];
            ArraysAreEquivalent(result, expecteArray);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.Merge([[1, 4], [4, 5]]);

            int[][] expecteArray = [[1, 5]];
            ArraysAreEquivalent(result, expecteArray);

        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.Merge([[1, 4]]);

            int[][] expecteArray = [[1, 4]];
            ArraysAreEquivalent(result, expecteArray);

        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.Merge([[1, 3], [2, 6], [1,1],[1,2],[1,3], [1, 4]
            ,[2, 2],[2, 5],[2, 3],[2, 4],
            [8, 10], [15, 18], [15, 15], [15, 16]]);

            int[][] expecteArray = [[1, 6], [8, 10], [15, 18]];
            ArraysAreEquivalent(result, expecteArray);

        }

        private static void ArraysAreEquivalent(int[][] result, int[][] expecteArray)
        {
            Assert.AreEqual(result.Length, expecteArray.Length);
            for (int i = 0; i < result.Length; i++)
            {
                CollectionAssert.AreEquivalent(result[i], expecteArray[i]);
            }
        }
    }
}