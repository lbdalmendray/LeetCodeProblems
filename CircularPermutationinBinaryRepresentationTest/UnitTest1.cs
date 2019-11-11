using System;
using System.Linq;
using CircularPermutationinBinaryRepresentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircularPermutationinBinaryRepresentationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.CircularPermutation(2, 3);
            CollectionAssert.AreEquivalent (result.ToArray(),new int[] { 3, 2, 0, 1 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.CircularPermutation(3, 2);
            CollectionAssert.AreEquivalent(result.ToArray(), new int[] { 2, 6, 7, 5, 4, 0, 1, 3 });
        }
    }
}
