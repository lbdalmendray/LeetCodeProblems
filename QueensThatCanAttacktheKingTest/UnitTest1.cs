using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueensThatCanAttacktheKing;

namespace QueensThatCanAttacktheKingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // [[0,1],[1,0],[4,0],[0,4],[3,3],[2,4]], king = [0,0]

        Solution s = new Solution();
            var result = s.QueensAttacktheKing(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 4, 0 }, new int[] { 0, 4 }, new int[] { 3, 3 }, new int[] { 2, 4 } }, new int[] { 0, 0 });
            CollectionAssert.IsSubsetOf(result.Select(e=>e.ToArray()).ToArray(), new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 3, 3 } });
            CollectionAssert.IsSubsetOf(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 3, 3 } }, result.Select(e=>e.ToArray()).ToArray());
        }
    }
}
