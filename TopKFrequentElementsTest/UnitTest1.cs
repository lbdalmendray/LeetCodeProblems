using TopKFrequentElements;

namespace TopKFrequentElementsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.TopKFrequent([1, 1, 1, 2, 2, 3], 2);
            
            Array.Sort(result);
            CollectionAssert.AreEquivalent(result, new int[] { 1, 2 });
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution solution = new Solution();
            var result = solution.TopKFrequent([-1, -1, -1, 2, 2, 3], 2);

            Array.Sort(result);
            CollectionAssert.AreEquivalent(result, new int[] { -1, 2 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.TopKFrequent([1, 1, 1, 2, 2, 3,3,3,3,3,3,3,5,5,5,5,5,5,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4], 2);

            Array.Sort(result);
            CollectionAssert.AreEquivalent(result, new int[] { 3, 4 });
        }
        [TestMethod]
        public void TestMethod22()
        {
            Solution solution = new Solution();
            var result = solution.TopKFrequent([1, 1, 1, 2, 2, -3, -3, -3, -3, -3, -3, -3, -5, -5, -5, -5, -5,-5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4], 2);

            Array.Sort(result);
            CollectionAssert.AreEquivalent(result, new int[] { -3, 4 });
        }
    }
}