using System;
using CountVowelsPermutation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountVowelsPermutationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.CountVowelPermutation(1), 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.CountVowelPermutation(2), 10);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /* 520762870 */ 
            Solution s = new Solution();
            Assert.AreEqual(s.CountVowelPermutation(144), 18208803);
        }
    }
}
