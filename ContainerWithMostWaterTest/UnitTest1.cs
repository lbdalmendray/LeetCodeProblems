using ContainerWithMostWater;

namespace ContainerWithMostWaterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();

            var result = solution.MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]);

            Assert.AreEqual(result, 49);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();

            var result = solution.MaxArea([1,1]);

            Assert.AreEqual(result, 1);
        }
    }
}