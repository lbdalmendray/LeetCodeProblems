using System;
using System.Collections.Generic;
using MaxLengthConcatenatedStringUniqueCharacters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxLengthConcatenatedStringUniqueCharactersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxLength(new List<string>() { "un", "iq", "ue" }), 4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxLength(new List<string>() { "cha", "r", "act", "ers" }), 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxLength(new List<string>() { "abcdefghijklmnopqrstuvwxyz" }), 26);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxLength(new List<string>() { "yy", "bkhwmpbiisbldzknpm" }), 0);
        }
    }
}
