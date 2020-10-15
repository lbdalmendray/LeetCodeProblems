using System;
using BinaryTreeUpsideDown;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeUpsideDownTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeNode node = new TreeNode(1);
            node.right = new TreeNode(3);
            node.left = new TreeNode(2);
            node.left.right = new TreeNode(5);
            node.left.left = new TreeNode(4);

            Solution s = new Solution();
            var result = s.UpsideDownBinaryTree(node);

            Assert.AreEqual(result.val, 4);
            Assert.AreEqual(result.left.val, 5);
            Assert.AreEqual(result.right.val, 2);
            Assert.AreEqual(result.right.left.val, 3);
            Assert.AreEqual(result.right.right.val, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.UpsideDownBinaryTree(null);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TreeNode node = new TreeNode(1);
            Solution s = new Solution();
            var result = s.UpsideDownBinaryTree(node);
            Assert.AreEqual(result.val, 1);
            Assert.AreEqual(result.left, null);
            Assert.AreEqual(result.right, null);
        }


        [TestMethod]
        public void TestMethod4()
        {
            TreeNode node = new TreeNode(1);
            node.right = new TreeNode(3);
            node.left = new TreeNode(2);
            node.left.right = new TreeNode(5);
            node.left.left = new TreeNode(4);
            node.right.right = new TreeNode(7);
            node.right.left = new TreeNode(6);

            Solution s = new Solution();
            var result = s.UpsideDownBinaryTree(node);
        
        }
    }
}
