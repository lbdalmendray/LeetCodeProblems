using Microsoft.VisualStudio.TestTools.UnitTesting;
using MostCommonWord;
using System;

namespace MostCommonWordTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit."
                , new string[] { "hit" });

            Assert.AreEqual("ball", result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MostCommonWord("a."
                , new string[] {  });

            Assert.AreEqual("a", result);
        }
    }
}
