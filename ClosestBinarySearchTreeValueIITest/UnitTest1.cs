using System;
using System.Linq;
using ClosestBinarySearchTreeValueII;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClosestBinarySearchTreeValueIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeNode node = new TreeNode(4);
            node.right = new TreeNode(5);
            node.left = new TreeNode(2);
            node.left.left = new TreeNode(1);
            node.left.right = new TreeNode(3);
            Solution s = new Solution();
            var result = s.ClosestKValues(node, 3.714286, 2);
            var expected = new int[] { 4, 3 };
            Array.Sort(expected);
            CollectionAssert.AreEquivalent(result.ToArray(), expected);
        }

        [TestMethod]
        public void TestMethod2()
        {
            TreeNode node = new TreeNode(4);
            node.right = new TreeNode(5);
            node.left = new TreeNode(2);
            node.left.left = new TreeNode(1);
            node.left.right = new TreeNode(3);
            Solution s = new Solution();
            var result = s.ClosestKValues(node, 3.714286, 3);
            var expected = new int[] { 4, 3 , 5 };
            Array.Sort(expected);
            CollectionAssert.AreEquivalent(result.ToArray(), expected);
        }
    }
}
