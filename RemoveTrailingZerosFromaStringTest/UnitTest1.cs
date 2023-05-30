using RemoveTrailingZerosFromaString;

namespace RemoveTrailingZerosFromaStringTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            string s = "51230100";

            var result = solution.RemoveTrailingZeros(s);

            Assert.IsTrue("512301" == result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            string s = "0";

            var result = solution.RemoveTrailingZeros(s);

            Assert.IsTrue("" == result);
        }
    }
}