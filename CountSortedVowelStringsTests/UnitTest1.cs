using CountSortedVowelStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountSortedVowelStringsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.CountVowelStrings(1);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.CountVowelStrings(2);
            Assert.AreEqual(result, 15);
        }
    }
}
