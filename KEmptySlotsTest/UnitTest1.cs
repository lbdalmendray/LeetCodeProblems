using KEmptySlots;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KEmptySlotsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            solution.KEmptySlots(new int[] { 1, 3, 2 }, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            solution.KEmptySlots(new int[] { 1,2,3 }, -1);
        }
    }
}
