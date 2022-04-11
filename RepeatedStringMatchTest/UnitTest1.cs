using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepeatedStringMatch;

namespace RepeatedStringMatchTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: a = "abcd", b = "cdabcdab"
Output: 3
Explanation: We return 3 because by repeating a three times "abcdabcdabcd", b is a substring of it.
             */

            Solution solution = new Solution();
            var result = solution.RepeatedStringMatch("abcd", "cdabcdab");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: a = "a", b = "aa"
Output: 2
             */

            Solution solution = new Solution();
            var result = solution.RepeatedStringMatch("a", "aa");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: a = "c", b = "aa"
             Output: 2
             */

            Solution solution = new Solution();
            var result = solution.RepeatedStringMatch("c", "aa");
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            /*
             Input: a = "abcdabcdabcd", b = "cda"
             Output: 1
             */

            Solution solution = new Solution();
            var result = solution.RepeatedStringMatch("abcdabcdabcd", "cda");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            /*
             Input: a = "", b = ""
             Output: 1
             */

            Solution solution = new Solution();
            var result = solution.RepeatedStringMatch("abcdabcdabcd", "c");
            Assert.AreEqual(result, 1);
        }
    }
}
