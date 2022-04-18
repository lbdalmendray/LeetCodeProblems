using ExpressiveWords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressiveWordsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: s = "heeellooo", words = ["hello", "hi", "helo"]
             Output: 1
             */

            Solution solution = new Solution();
            var result = solution.ExpressiveWords("heeellooo", new string[] { "hello", "hi", "helo" });
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: s = "zzzzzyyyyy", words = ["zzyy","zy","zyy"]
             Output: 3
             */

            Solution solution = new Solution();
            var result = solution.ExpressiveWords("zzzzzyyyyy", new string[] { "zzyy", "zy", "zyy" });
            Assert.AreEqual(result, 3);
        }
    }
}
