using Microsoft.VisualStudio.TestTools.UnitTesting;
using OddEvenJump;

namespace OddEvenJumpTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: arr = [10,13,12,14,15]
             Output: 2
             */
            Solution solution = new Solution();
            var result = solution.OddEvenJumps(new int[] { 10, 13, 12, 14, 15 });
            Assert.AreEqual(result, 2);
        }


        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: arr = [2,3,1,1,4]
             Output: 3
             */
            Solution solution = new Solution();
            var result = solution.OddEvenJumps(new int[] { 2, 3, 1, 1, 4 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: arr = [5,1,3,4,2]
             Output: 3
             */
            Solution solution = new Solution();
            var result = solution.OddEvenJumps(new int[] { 5, 1, 3, 4, 2 });
            Assert.AreEqual(result, 3);
        }
    }
}
