using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonCellsAfterNDays;

namespace PrisonCellsAfterNDaysTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
            
           Input: cells = [0,1,0,1,1,0,0,1], n = 7
Output: [0,0,1,1,0,0,0,0]

             */

            Solution solution = new Solution();
            var result = solution.PrisonAfterNDays
                (
                new int[] { 0, 1, 0, 1, 1, 0, 0, 1 }
                , 7
                );
            CollectionAssert.AreEquivalent(result, new int[] { 0, 0, 1, 1, 0, 0, 0, 0 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
            
            Input: cells = [1,0,0,1,0,0,1,0], n = 1000000000
           Output: [0,0,1,1,1,1,1,0]

             */

            Solution solution = new Solution();
            var result = solution.PrisonAfterNDays
                (
                new int[] { 1, 0, 0, 1, 0, 0, 1, 0 }
                , 1000000000
                );

            CollectionAssert.AreEquivalent(result, new int[] { 0, 0, 1, 1, 1, 1, 1, 0 });

        }
    }
}
