using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueensThatCanAttacktheKing;
using Utils;

namespace QueensThatCanAttacktheKingTest
{
    [TestClass]
    public class UnitTest1
    {
        EnumerableComparer<int[]> enumerableComparer = new EnumerableComparer<int[]>(Comparer<int[]>.Create((ar1, ar2) => ar1[0] == ar2[0] && ar1[1] == ar2[1] ? 0 : 1));
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.QueensAttacktheKing(new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 4, 0 }, new int[] { 0, 4 }, new int[] { 3, 3 }, new int[] { 2, 4 } }, new int[] { 0, 0 });
            Assert.IsTrue(enumerableComparer.Equivalent(result.Select(e => e.ToArray()).ToArray(), new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 3, 3 } }));
        }
    }
}
