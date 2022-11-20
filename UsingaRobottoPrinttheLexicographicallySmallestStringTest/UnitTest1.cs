using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UsingaRobottoPrinttheLexicographicallySmallestString;

namespace UsingaRobottoPrinttheLexicographicallySmallestStringTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.RobotWithString("zza");
            Assert.AreEqual(result, "azz");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.RobotWithString("bac");
            Assert.AreEqual(result, "abc");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.RobotWithString("bdda");
            Assert.AreEqual(result, "addb");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.RobotWithString("abcdabcda");
            Assert.AreEqual(result, "aaadcbdcb");
        }

        /// "vzhofnpo"
        
        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.RobotWithString("vzhofnpo");
            Assert.AreEqual(result, "fnohopzv");
        }
    }
}
