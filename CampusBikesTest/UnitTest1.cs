using CampusBikes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CampusBikesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: workers = [[0,0],[2,1]], bikes = [[1,2],[3,3]]
Output: [1,0]
             */

            Solution solution = new Solution();
            var result = solution.AssignBikes(
                new int[][] { new int[] { 0, 0 }, new int[] { 2, 1 } },
                new int[][] { new int[] { 1, 2 }, new int[] { 3, 3 } }
                );

            CollectionAssert.AreEqual(result, new int[] { 1, 0 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: workers = [[0,0],[1,1],[2,0]], bikes = [[1,0],[2,2],[2,1]]
Output: [0,2,1]
             */

            Solution solution = new Solution();
            var result = solution.AssignBikes(
                new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 0 } },
                new int[][] { new int[] { 1, 0 }, new int[] { 2, 2 }, new int[] { 2, 1 } }
                );

            CollectionAssert.AreEqual(result, new int[] { 0, 2, 1 });
        }
    }
}
