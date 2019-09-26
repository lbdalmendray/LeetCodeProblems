using System;
using BinaryTreeMaximumPathSum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeMaximumPathSumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeNode node = new TreeNode(2);
            node.left = new TreeNode(1);
            node.right = new TreeNode(3);

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node),6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            TreeNode node = new TreeNode(-10);
            node.left = new TreeNode(9);
            node.right = new TreeNode(20);
            node.right.left = new TreeNode(15);
            node.right.right = new TreeNode(7);

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node), 42);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TreeNode node = new TreeNode(-10);
            node.left = new TreeNode(9);
            node.right = new TreeNode(20);
            node.right.left = new TreeNode(15);

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node), 35);
        }

        [TestMethod]
        public void TestMethod4()
        {
            TreeNode node = new TreeNode(-10);
            node.left = new TreeNode(-9);
            node.right = new TreeNode(-20);

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node), -9);
        }

        [TestMethod]
        public void TestMethod5()
        {
            TreeNode node = new TreeNode(-9);
            node.left = new TreeNode(-9);
            node.right = new TreeNode(-9);

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node), -9);
        }


        [TestMethod]
        public void TestMethod6()
        {
            TreeNode node = new TreeNode(-9);

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node), -9);
        }

        [TestMethod]
        public void TestMethod7()
        {
            TreeNode node = GetTreeNodeFromIntArray(new int[] { 1, 0, 1, 1, 2, 0, -1, 0, 1, -1, 0, -1, 0, 1, 0 });

            Solution solution = new Solution();
            Assert.AreEqual(solution.MaxPathSum(node), 4);
        }

        TreeNode GetTreeNodeFromIntArray(int [] array)
        {
            TreeNode[] treeNodeArray = new TreeNode[array.Length];
            for (int i = 0; i < treeNodeArray.Length; i++)
            {
                treeNodeArray[i] = new TreeNode(array[i]);
            }
            int lastValuePlus1 = array.Length / 2 ;
            for (int i = 0;  i < lastValuePlus1  ; i++)
            {
                treeNodeArray[i].left = treeNodeArray[2 * (i+1) - 1];
                treeNodeArray[i].right = 2*(i+1) < array.Length ? treeNodeArray[2 * (i+1) ] : null ;
            }

            return treeNodeArray[0];
        }
    }
}
