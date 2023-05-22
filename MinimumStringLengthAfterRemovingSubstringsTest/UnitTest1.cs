using MinimumStringLengthAfterRemovingSubstrings;

namespace MinimumStringLengthAfterRemovingSubstringsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MinLength("ABFCACDB");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MinLength("A");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MinLength("ACAAAAABBBBBDB");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.MinLength("ACAAAAABBBBBDBABFCACDB");
            Assert.AreEqual(result, 0 + 2);
        }
    }
}