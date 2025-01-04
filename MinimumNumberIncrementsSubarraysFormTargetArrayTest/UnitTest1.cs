using MinimumNumberIncrementsSubarraysFormTargetArray;

namespace MinimumNumberIncrementsSubarraysFormTargetArrayTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            int result = solution.MinNumberOperations([1, 2, 3, 2, 1]);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            int result = solution.MinNumberOperations([3, 1, 1, 2]);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            int result = solution.MinNumberOperations([3, 1, 5, 4, 2]);
            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            int result = solution.MinNumberOperations(
                [1, 10, 8, 7, 9, 9, 1, 9]);
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            int result = solution.MinNumberOperations(
                [1,1,1,1,1,1]);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            int result = solution.MinNumberOperations(
                [7,7,7,7,7,7,7,7,7,7,7,7]);
            Assert.AreEqual(result, 7);
        }
    }
}