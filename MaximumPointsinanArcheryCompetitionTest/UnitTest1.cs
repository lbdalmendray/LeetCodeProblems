using MaximumPointsinanArcheryCompetition;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MaximumPointsinanArcheryCompetitionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: numArrows = 9, aliceArrows = [1,1,0,1,0,0,2,1,0,1,2,0]
            Output: [0,0,0,0,1,1,0,0,1,2,3,1]
             */

            Solution solution = new Solution();
            var result = solution.MaximumBobPoints(9, new int[] { 1, 1, 0, 1, 0, 0, 2, 1, 0, 1, 2, 0 });
            CollectionAssert.AreEquivalent(
                result,
                new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 1, 2, 3, 1 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: numArrows = 3, aliceArrows = [0,0,1,0,0,0,0,0,0,0,0,2]
            Output: [0,0,0,0,0,0,0,0,1,1,1,0]
             */

            Solution solution = new Solution();
            var result = solution.MaximumBobPoints(3, new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2 });
            CollectionAssert.AreEquivalent(
                result,
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 });
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
             89
[3,2,28,1,7,1,16,7,3,13,3,5]
             */

            Solution solution = new Solution();
            var result = solution.MaximumBobPoints(89, new int[] { 3, 2, 28, 1, 7, 1, 16, 7, 3, 13, 3, 5 });
            CollectionAssert.AreEquivalent(
                result, 
                new int[] {21, 3, 0, 2, 8, 2, 17, 8, 4, 14, 4, 6});
        }
    }
}
