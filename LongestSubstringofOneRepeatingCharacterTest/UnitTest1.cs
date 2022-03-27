using LongestSubstringofOneRepeatingCharacter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestSubstringofOneRepeatingCharacterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: s = "babacc", queryCharacters = "bcb", queryIndices = [1,3,3]
Output: [3,3,4]
             */

            Solution solution = new Solution();
            var result = solution.LongestRepeating("babacc", "bcb", new int[] { 1, 3, 3 });
            CollectionAssert.AreEquivalent(new int[] { 3, 3, 4 }, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: s = "abyzz", queryCharacters = "aa", queryIndices = [2,1]
Output: [2,3]
             */

            Solution solution = new Solution();
            var result = solution.LongestRepeating("abyzz", "aa", new int[] { 2,1 });
            CollectionAssert.AreEquivalent(new int[] { 2,3 }, result);
        }


        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: s = "a", queryCharacters = "bcdefg", queryIndices = [0,0,0,0,0,0]
Output: [2,3]
             */

            Solution solution = new Solution();
            var result = solution.LongestRepeating("a", "bcdefg", new int[] { 0, 0, 0, 0, 0, 0 });
            CollectionAssert.AreEquivalent(new int[] { 1,1,1,1,1,1 }, result);
        }
    }
}
