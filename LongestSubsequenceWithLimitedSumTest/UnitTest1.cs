using LongestSubsequenceWithLimited_Sum;

namespace LongestSubsequenceWithLimitedSumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();

            var result = solution.AnswerQueries(new int[]
            {
                4,5,2,1
            }, new int[]
            {
                3,10,21
            });

            CollectionAssert.AreEquivalent(new int[] { 2, 3, 4 }, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();

            var result = solution.AnswerQueries(new int[]
            {
                2,3,4,5
            }, new int[]
            {
                1
            });

            CollectionAssert.AreEquivalent(new int[] { 0 }, result);
        }
    }
}