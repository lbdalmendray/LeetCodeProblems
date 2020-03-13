using System;
using LinkedListinBinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListinBinaryTreeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
                                         //1 2 3 4    5 6 7    8  9  10 11 12  13    14   15 16 17             
            Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true
            
            */

            Solution s = new Solution();
            
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(4);
            root.left.right = new TreeNode(2);
            root.left.right.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.right.left = new TreeNode(2);
            root.right.left.left = new TreeNode(6);
            root.right.left.right = new TreeNode(8);
            root.right.left.right.left = new TreeNode(1);
            root.right.left.right.right = new TreeNode(3);

            ListNode head = new ListNode(4);
            head.next = new ListNode(2);
            head.next.next = new ListNode(8);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
                                         
            */

            Solution s = new Solution();

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);

            ListNode head = new ListNode(1);
            head.next = new ListNode(3);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod4()
        {
           
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(4);
            root.left.right = new TreeNode(2);
            root.left.right.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.right.left = new TreeNode(2);
            root.right.left.left = new TreeNode(6);
            root.right.left.right = new TreeNode(8);
            root.right.left.right.left = new TreeNode(1);
            root.right.left.right.right = new TreeNode(3);

            ListNode head = new ListNode(1);
            head.next = new ListNode(4);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(6);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(4);
            root.left.right = new TreeNode(2);
            root.left.right.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.right.left = new TreeNode(2);
            root.right.left.left = new TreeNode(6);
            root.right.left.right = new TreeNode(8);
            root.right.left.right.left = new TreeNode(1);
            root.right.left.right.right = new TreeNode(3);

            ListNode head = new ListNode(1);
            head.next = new ListNode(4);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(6);
            head.next.next.next.next = new ListNode(8);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);
            
            ListNode head = new ListNode(1);
            
            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);

            ListNode head = new ListNode(3);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            TreeNode root = new TreeNode(1);

            root.right = new TreeNode(2);

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    root = root.right;
                    root.left = new TreeNode(2);
                }
                else
                {
                    root = root.left;
                    root.right = new TreeNode(2);
                }
            }

            ListNode head = new ListNode(2);
            head.next = new ListNode(2);
            
            for (int i = 0; i < 50; i++)
            {
                head = head.next;
                head.next = new ListNode(2);
            }

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, true);
        }


        [TestMethod]
        public void TestMethod9()
        {
            /*
            
            [1,10]
[1,null,1,10,1,9]
            
            */

            Solution s = new Solution();
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(1);
            root.right.left = new TreeNode(10);
            root.right.left.left = new TreeNode(9);
            root.right.right = new TreeNode(1);

            ListNode head = new ListNode(1);
            head.next = new ListNode(10);

            var result = s.IsSubPath(head, root);
            Assert.AreEqual(result, true);
        }
    }
}
