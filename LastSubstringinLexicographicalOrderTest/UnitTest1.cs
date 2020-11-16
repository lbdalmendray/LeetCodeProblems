using LastSubstringinLexicographicalOrder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LastSubstringinLexicographicalOrderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.LastSubstring("abab");
            Assert.AreEqual(result, "bab");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.LastSubstring("leetcode");
            Assert.AreEqual(result, "tcode");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.LastSubstring("aaaaaazaaaaaaazaaaaaaaaazaaa");
            Assert.AreEqual(result, "zaaaaaaazaaaaaaaaazaaa");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.LastSubstring("aaaaaazaacaaaazaadaaaaaazaad");
            Assert.AreEqual(result, "zaadaaaaaazaad");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.LastSubstring("aaaaaazadcaaaazadaaaaaaazadd");
            Assert.AreEqual(result, "zadd");
        }
    }
}
