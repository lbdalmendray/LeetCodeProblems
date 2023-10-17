using LongestSubstringWithou_RepeatingCharacters;

namespace LongestSubstringWithou_RepeatingCharactersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.LengthOfLongestSubstring("abcabcbb");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.LengthOfLongestSubstring("bbbbb");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.LengthOfLongestSubstring("pwwkew");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.LengthOfLongestSubstring("aaaabcdefghiawert");
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.LengthOfLongestSubstring("");
            Assert.AreEqual(result, 0);
        }
    }
}