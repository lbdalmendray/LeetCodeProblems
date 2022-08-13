using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransformsIntoAnotherString;
using System.Linq;

namespace StringTransformsIntoAnotherStringTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: str1 = "aabcc", str2 = "ccdee"
Output: true
Explanation: Convert 'c' to 'e' then 'b' to 'd' then 'a' to 'c'. Note that the order of conversions matter.
             */

            Solution solution = new Solution();
            var result = solution.CanConvert("aabcc", "ccdee");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod1_1()
        {
            /*
             Input: str1 = "aabcc", str2 = "ccdee"
Output: true
Explanation: Convert 'c' to 'e' then 'b' to 'd' then 'a' to 'c'. Note that the order of conversions matter.
             */

            Solution solution = new Solution();
            var result = solution.CanConvert1("aabcc", "ccdee");
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: str1 = "leetcode", str2 = "codeleet"
             Output: false
             Explanation: There is no way to transform str1 to str2.
            */

            Solution solution = new Solution();
            var result = solution.CanConvert("leetcode", "codeleet");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod2_1()
        {
            /*
             Input: str1 = "leetcode", str2 = "codeleet"
             Output: false
             Explanation: There is no way to transform str1 to str2.
            */

            Solution solution = new Solution();
            var result = solution.CanConvert1("leetcode", "codeleet");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.CanConvert("iizziizzjjii", "aabbaabbaabb");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod3_1()
        {
            Solution solution = new Solution();
            var result = solution.CanConvert1("iizziizzjjii", "aabbaabbaabb");
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var alphabet = "qwertyuiopasdfghjklzxcvbnm";
            var alphRotated = "mqwertyuiopasdfghjklzxcvbn";
            Solution solution = new Solution();
            var result = solution.CanConvert(alphRotated, alphabet);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod4_1()
        {
            var alphabet = "qwertyuiopasdfghjklzxcvbnm";
            var alphRotated = "mqwertyuiopasdfghjklzxcvbn";
            Solution solution = new Solution();
            var result = solution.CanConvert1(alphRotated, alphabet);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var alphabet = "qwertyuiopasdfghjklzxvbnm";
            var alphRotated = "mqwertyuiopasdfghjklzxvbn";
            Solution solution = new Solution();
            var result = solution.CanConvert(alphRotated, alphabet);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod5_1()
        {
            var alphabet = "qwertyuiopasdfghjklzxvbnm";
            var alphRotated = "mqwertyuiopasdfghjklzxvbn";
            Solution solution = new Solution();
            var result = solution.CanConvert1(alphRotated, alphabet);
            Assert.AreEqual(result, true);
        }

    }

}
