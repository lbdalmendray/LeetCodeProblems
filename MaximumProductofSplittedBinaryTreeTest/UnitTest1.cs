using System;
using MaximumProductofSplittedBinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumProductofSplittedBinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(4);
            root.right.right.left = new TreeNode(5);
            root.right.right.right = new TreeNode(6);
            var result = s.MaxProduct(root);
            Assert.AreEqual(result, 90);
        }
    }
}
