using DetermineifTwoStringsAreClose;

namespace DetermineifTwoStringsAreCloseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.CloseStrings("abc", "bca");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.CloseStrings("a", "aa");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.CloseStrings("cabbba", "abbccc");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.CloseStrings(
                new string(Enumerable.Repeat("ab",5000)
                .SelectMany(e=>e)
                .ToArray()),
                new string(Enumerable.Repeat("ba", 5000)
                .SelectMany(e => e)
                .ToArray()));
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.CloseStrings(
                new string(Enumerable.Repeat("abz", 5000)
                .SelectMany(e => e)
                .ToArray()),
                new string(Enumerable.Repeat("bac", 5000)
                .SelectMany(e => e)
                .ToArray()));
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            var result = solution.CloseStrings(
                new string(Enumerable.Repeat("ab", 5000)
                .SelectMany(e => e)
                .Concat("yyz")
                .ToArray()),
                new string(Enumerable.Repeat("ba", 5000)
                .SelectMany(e => e)
                .Concat("zzy")
                .ToArray()));
            Assert.AreEqual(result, true);
        }
    }
}