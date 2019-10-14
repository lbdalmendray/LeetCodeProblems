using System;
using GetEqualSubstringsWithinBudget;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetEqualSubstringsWithinBudgetTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             "abcd"
"cdef"
3
             */

            Solution s = new Solution();
            Assert.AreEqual(1, s.EqualSubstring("abcd", "cdef", 3));
        }
    }
}
