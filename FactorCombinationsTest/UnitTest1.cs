using System;
using System.Collections.Generic;
using System.Linq;
using FactorCombinations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactorCombinationsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.GetFactors(1);
            LinkedList<IList<int>> expected = new LinkedList<IList<int>>();
            CollectionAssert.AreEquivalent(result.ToArray(), expected.ToArray());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.GetFactors(37);
            LinkedList<IList<int>> expected = new LinkedList<IList<int>>();
            CollectionAssert.AreEquivalent(result.ToArray(), expected.ToArray());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.GetFactors(12);
            IList<IList<int>> expected = new List<IList<int>>();
            List<int> current1 = new List<int> { 2, 6 };
            expected.Add(current1);
            current1 = new List<int> { 2, 2, 3 };
            expected.Add(current1);
            current1 = new List<int> { 3, 4 };
            expected.Add(current1);
            var expectedArray = expected.ToArray();
            Array.Sort(expectedArray, GetComparer());
            var resultArray = result.ToArray();
            Array.Sort(resultArray, GetComparer());
            Assert.IsTrue(EquivalentLists(resultArray, expectedArray));
        }

        [TestMethod]
        public void TestMethod4()
        {
            /*
              [2, 16],
  [2, 2, 8],
  [2, 2, 2, 4],
  [2, 2, 2, 2, 2],
  [2, 4, 4],
  [4, 8]
             */

            Solution s = new Solution();
            var result = s.GetFactors(32);
            IList<IList<int>> expected = new List<IList<int>>();
            List<int> current1 = new List<int> { 2, 16 };
            expected.Add(current1);
            current1 = new List<int> { 2, 2, 8 };
            expected.Add(current1);
            current1 = new List<int> { 2, 2, 2, 4 };
            expected.Add(current1);
            current1 = new List<int> { 2,2,2,2,2 };
            expected.Add(current1);
            current1 = new List<int> { 2, 4, 4 };
            expected.Add(current1);
            current1 = new List<int> { 4, 8 };
            expected.Add(current1);
            var expectedArray = expected.ToArray();
            Array.Sort(expectedArray, GetComparer());
            var resultArray = result.ToArray();
            Array.Sort(resultArray, GetComparer());
            Assert.IsTrue(EquivalentLists(resultArray, expectedArray));
        }

        private bool EquivalentLists(IList<IList<int>> list1, IList<IList<int>> list2)
        {
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++)
            {
                var list11 = list1[i];
                var list21 = list2[i];

                if (list11.Count != list21.Count)
                    return false;

                for (int j = 0; j < list11.Count; j++)
                {
                    if (list11[j] != list21[j])
                        return false;
                }
            }

            return true;
        }
        private IComparer<IList<int>> GetComparer()
        {
            return Comparer<IList<int>>.Create(Compare);
        }

        private int Compare(IList<int> a, IList<int> b)
        {
            int minLength = Math.Min(a.Count, b.Count);
            for (int i = 0; i < minLength; i++)
            {
                if (a[i] < b[i])
                    return -1;
                else if (a[i] > b[i])
                    return 1;
            }
            return a.Count - b.Count;
        }
    }
}
