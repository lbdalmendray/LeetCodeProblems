using KEmptySlots;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KEmptySlotsTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution2 solution = new Solution2();
            solution.KEmptySlots(new int[] { 1, 3, 2 }, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution2 solution = new Solution2();
            solution.KEmptySlots(new int[] { 1,2,3 }, -1);
        }
    }
}
