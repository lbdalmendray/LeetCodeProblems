using System;
using ConstructBinaryTreefromPreorderandInorderTraversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructBinaryTreefromPreorderandInorderTraversalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
            TreeNode node = new TreeNode(3);
            node.left = new TreeNode(9);
            node.right = new TreeNode(20);
            node.right.left = new TreeNode(15);
            node.right.right = new TreeNode(7);
            Assert.IsTrue(AreEquals(result, node));
        }


        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.BuildTree(new int[] { 3, 4, 5, 6  }, new int[] { 3, 4, 5, 6 });
            TreeNode node = new TreeNode(3);
            node.right = new TreeNode(4);
            node.right.right = new TreeNode(5);
            node.right.right.right = new TreeNode(6);
            Assert.IsTrue(AreEquals(result, node));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.BuildTree(new int[] { 3,7,11,9,0,4,5,6 }, new int[] { 11,7,0,9,3,4,5,6 });
            TreeNode node = new TreeNode(3);
            node.left = new TreeNode(7);
            node.left.left = new TreeNode(11);
            node.left.right = new TreeNode(9);
            node.left.right.left = new TreeNode(0);
            node.right = new TreeNode(4);
            node.right.right = new TreeNode(5);
            node.right.right.right = new TreeNode(6);
            Assert.IsTrue(AreEquals(result, node));
        }

        private bool AreEquals(TreeNode node1, TreeNode node2)
        {
            if (node1 == null)
                return node2 == null;

            if (node2 == null)
                return node1 == null;


            if (node1.val != node2.val)
                return false;


            var result = AreEquals(node1.left, node1.left);

            if (!result)
                return false;

            result = AreEquals(node1.right, node1.right);

            if (!result)
                return false;

            return true;
        }
    }
}
