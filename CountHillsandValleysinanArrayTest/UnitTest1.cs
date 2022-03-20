using CountHillsandValleysinanArray;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountHillsandValleysinanArrayTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.CountHillValley(new int[] { 2, 4, 1, 1, 6, 5 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.CountHillValley(new int[] { 6, 6, 5, 5, 4, 1 });
            Assert.AreEqual(result, 0);
        }
    }
}
