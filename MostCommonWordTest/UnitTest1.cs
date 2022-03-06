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

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MostCommonWord("Lion's family can be together. Lion is an animal."
                , new string[] { });

            Assert.AreEqual("lion", result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.MostCommonWord("I bougth some things like pencils,papers and pens. Pencils are very useful", new string[] { });

            Assert.AreEqual("pencils", result);
        }
    }
}
