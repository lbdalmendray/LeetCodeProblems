namespace MinimumAdjacentSwapstoMakeaValidArray.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MinimumSwaps([3, 4, 5, 5, 3, 1]);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MinimumSwaps([9]);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MinimumSwaps([5,5,5,6,6,6,4,4,4,7,7,7,7,3,3,3,8,8,8,8,2,2,2,2,2,9,9,9,9,9,1,1,1,1,5,5,5,5]);
            Assert.AreEqual(result, 37);
        }
    }
}