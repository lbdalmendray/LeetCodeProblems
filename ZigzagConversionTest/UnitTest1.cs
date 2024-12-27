using ZigzagConversion;

namespace ZigzagConversionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.Convert(s: "PAYPALISHIRING", numRows: 3);
            Assert.AreEqual(result, "PAHNAPLSIIGYIR");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.Convert(s: "PAYPALISHIRING", numRows: 4);
            Assert.AreEqual(result, "PINALSIGYAHRPI");
        }


        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.Convert(s: "A", numRows: 1);
            Assert.AreEqual(result, "A");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.Convert(s: "ABCDEFGHIJKL", numRows: 1);
            Assert.AreEqual(result, "ABCDEFGHIJKL");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.Convert(s: "ABCD", numRows: 8);
            Assert.AreEqual(result, "ABCD");
        }
    }
}