using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveAllAdjacentDuplicatesinStringII;

namespace RemoveAllAdjacentDuplicatesinStringIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: s = "deeedbbcccbdaa", k = 3
Output: "aa"
             */

            Solution solution = new Solution();

            Assert.AreEqual("aa", solution.RemoveDuplicates("deeedbbcccbdaa", 3));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();

            Assert.AreEqual("abcd", solution.RemoveDuplicates("abcd", 2));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();

            Assert.AreEqual("ps",solution.RemoveDuplicates("pbbcggttciiippooaais", 2));
        }
    }
}
