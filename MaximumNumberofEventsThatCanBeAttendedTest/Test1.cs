using MaximumNumberofEventsThatCanBeAttended;

namespace MaximumNumberofEventsThatCanBeAttendedTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MaxEvents([[1, 2], [2, 3], [3, 4]]);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MaxEvents([[1, 2], [2, 3], [3, 4], [1, 2]]);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MaxEvents([[1, 2], [1, 2], [1, 3]]);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.MaxEvents([[1, 2], [1, 2], [1, 3]]);
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.MaxEvents([[1, 2], [1, 2], [3, 3], [1, 5], [1, 5]]);
            Assert.AreEqual(result, 5);
        }


        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            var result = solution.MaxEvents([[1,4], [1,4], [3,3] , [1,4], [ 4,4], [6, 6], [6,6], [6,7]]);
            Assert.AreEqual(result, 6);
        }
    }
}
