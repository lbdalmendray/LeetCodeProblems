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

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();

            List<int> nums = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    nums.Add(i);
                }
            }

            int [] queries = Enumerable.Range(0, 100_000).Select(e => Enumerable.Range(0, 5).Select(_ => e)).SelectMany(x => x).ToArray();
            var result1 = solution.AnswerQueries(nums.ToArray(), queries);
            var result2 = solution.AnswerQueries2(nums.ToArray(), queries);
            CollectionAssert.AreEquivalent(result1, result2);
        }
    }
}