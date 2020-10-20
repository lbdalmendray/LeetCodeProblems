using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntersectionofTwoArrays;

namespace IntersectionofTwoArraysTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.Intersection(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 });
            Array.Sort(result);
            int [] compareArray = new int[] { 2 };
            Array.Sort(compareArray);
            CollectionAssert.AreEquivalent(result, compareArray);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.Intersection(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
            Array.Sort(result);
            int[] compareArray = new int[] { 9, 4 };
            Array.Sort(compareArray);
            CollectionAssert.AreEquivalent(result, compareArray);
        }
    }
}
