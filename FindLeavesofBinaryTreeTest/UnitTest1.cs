using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FindLeavesofBinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindLeavesofBinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
                         1            1         1
                        / \          /
                       2   3   ---> 2     ---> 
                      / \            
                     4   5           
            */

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            Solution s = new Solution();
            IList<IList<int>> result = s.FindLeaves(root);
            List<int> list = new List<int>();
            list.Add(4);
            list.Add(5);
            list.Add(3);
            CollectionAssert.AreEquivalent(result[0].ToArray(), list.ToArray());

            list = new List<int>();
            list.Add(2);
            CollectionAssert.AreEquivalent(result[1].ToArray(), list.ToArray());

            list = new List<int>();
            list.Add(1);
            CollectionAssert.AreEquivalent(result[2].ToArray(), list.ToArray());

        }


        [TestMethod]
        public void TestMethod2()
        {
            /*
                        EMPTY        
            */

            Solution s = new Solution();
            IList<IList<int>> result = s.FindLeaves(null);
            Assert.AreEqual(result.Count, 0);
        }

        //[]
    }
}
