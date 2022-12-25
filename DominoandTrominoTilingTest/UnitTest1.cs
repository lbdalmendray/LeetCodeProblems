using DominoandTrominoTiling;

namespace DominoandTrominoTilingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(1);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(2);
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(3);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(4);
            Assert.AreEqual(result,11);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(5);
            Assert.AreEqual(result, 24);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(6);
            Assert.AreEqual(result, 53);
        }

        [TestMethod]
        public void TestMethod20()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(20);
            Assert.AreEqual(result, 3418626);
        }

        [TestMethod]
        public void TestMethod1000()
        {
            Solution solution = new Solution();
            var result = solution.NumTilings(1000);
            Assert.AreEqual(result, 979232805);
        }
    }
}