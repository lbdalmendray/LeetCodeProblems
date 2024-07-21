using MultiplyStrings;

namespace MultiplyStringsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            for (int i = 0; i <= 100; i++)
            {
                var iString = i.ToString();
                for (int j = 0; j <= 100; j++)
                {
                    var result = solution.Multiply(iString, j.ToString());
                    Assert.AreEqual(int.Parse(result), i * j, $"{i} * {j}");
                }
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.Multiply("1", "1");
            Assert.AreEqual(int.Parse(result), 1, $"1 * 1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.Multiply("3", "34");
            Assert.AreEqual(int.Parse(result), 3*34, $"3 * 34");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.Multiply("2", "3");
            Assert.AreEqual(int.Parse(result), 6, $"2 * 3");
        }
    }
}