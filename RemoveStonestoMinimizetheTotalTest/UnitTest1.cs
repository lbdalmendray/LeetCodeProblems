using RemoveStonestoMinimizetheTotal;

namespace RemoveStonestoMinimizetheTotalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MinStoneSum(new int[]
            {
                5,4,9
            }, 2);

            Assert.AreEqual(result, 12);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MinStoneSum(new int[]
            {
                4,3,6,7
            }, 3);

            Assert.AreEqual(result, 12);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MinStoneSum(new int[]
            {
                128, 64, 32, 16, 8, 4, 2
            }, 1+2+3+4+5+6+7);

            Assert.AreEqual(result, 7);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.MinStoneSum(new int[]
            {
                128,128, 64,64, 32,32, 16,16, 8,8, 4,4, 2,2
            }, 2*(1 + 2 + 3 + 4 + 5 + 6 + 7));

            Assert.AreEqual(result, 14);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.MinStoneSum(new int[]
            {
                128+1,128, 64+1,64, 32+1,32, 16+1,16, 8+1,8, 4+1,4, 2+1,2
            }, 2 * (1 + 2 + 3 + 4 + 5 + 6 + 7));

            Assert.AreEqual(result, 14+7);
        }
    }
}