using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializeAndDeserializeBinaryTree;

namespace SerializeAndDeserializeBinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TreeNode treeNode = new TreeNode(1);
            treeNode.left = new TreeNode(2);
            treeNode.right = new TreeNode(3);
            treeNode.right.left = new TreeNode(4);
            treeNode.right.right = new TreeNode(5);
            Codec codec = new Codec();
            var stringCoding = codec.serialize(treeNode);
            var treeNodeResult = codec.deserialize(stringCoding);
            Assert.IsTrue(AreEquals(treeNode, treeNodeResult));
        }

        [TestMethod]
        public void TestMethod2()
        {
            TreeNode treeNode = new TreeNode(1);
            Codec codec = new Codec();
            var stringCoding = codec.serialize(treeNode);
            var treeNodeResult = codec.deserialize(stringCoding);
            Assert.IsTrue(AreEquals(treeNode, treeNodeResult));
        }

        [TestMethod]
        public void TestMethod3()
        {
            TreeNode treeNode = null;
            Codec codec = new Codec();
            var stringCoding = codec.serialize(treeNode);
            var treeNodeResult = codec.deserialize(stringCoding);
            Assert.IsTrue(AreEquals(treeNode, treeNodeResult));
        }

        private bool AreEquals(TreeNode treeNode, TreeNode treeNodeResult)
        {
            if (treeNode == null && treeNodeResult != null)
                return false;
            if (treeNode != null && treeNodeResult == null)
                return false;
            if (treeNode == null && treeNodeResult == null)
                return true;
            if (treeNode.val != treeNodeResult.val)
                return false;
            if (!AreEquals(treeNode.left, treeNodeResult.left))
                return false;
            if (!AreEquals(treeNode.right, treeNodeResult.right))
                return false;
            return true;
        }
    }
}
