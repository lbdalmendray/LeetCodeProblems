using System;
using CopyListwithRandomPointer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopyListwithRandomPointerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
        Input: head = [[7, null],[13,0],[11,4],[10,2],[1,0]]
Output: [[7,null],[13,0],[11,4],[10,2],[1,0]]
*/

            Node head = new Node(7);
            
            head.next = new Node(13);
            head.next.random = head;

            head.next.next = new Node(11);
         // head.next.next.random = head.next.next.next.next ;

            head.next.next.next = new Node(10);
            head.next.next.next.random = head.next.next;

            head.next.next.next.next = new Node(1);
            head.next.next.next.next.random = head;

            head.next.next.random = head.next.next.next.next;

            Solution s = new Solution();
            var headClone = s.CopyRandomList(head);

            while(head != null)
            {
                Assert.IsTrue(AreEqual(head , headClone));
                head = head.next;
                headClone = headClone.next;
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
        Input: head = [[1,1],[2,1]]
Output: [[1,1],[2,1]]
*/

            Node head = new Node(1);
            head.next = new Node(2);
            head.random = head.next;
            head.next.random = head.next;

            Solution s = new Solution();
            var headClone = s.CopyRandomList(head);

            while (head != null)
            {
                Assert.IsTrue(AreEqual(head, headClone));
                head = head.next;
                headClone = headClone.next;
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
        Input: head = [[3,null],[3,0],[3,null]]
Output: [[3,null],[3,0],[3,null]]
*/

            Node head = new Node(3);
            head.next = new Node(3);
            head.next.random = head;
            head.next.next = new Node(3);

            Solution s = new Solution();
            var headClone = s.CopyRandomList(head);

            while (head != null)
            {
                Assert.IsTrue(AreEqual(head, headClone));
                head = head.next;
                headClone = headClone.next;
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            /*
        Input: head = []
Output: []
*/

            Node head = null;

            Solution s = new Solution();
            var headClone = s.CopyRandomList(head);
            if (head == null)
                Assert.IsTrue(headClone == null);

            while (head != null)
            {
                Assert.IsTrue(AreEqual(head, headClone));
                head = head.next;
                headClone = headClone.next;
            }
        }

        private bool AreEqual(Node head, Node headClone)
        {
            if (head.val != headClone.val)
                return false;
            if (head.next == null)
                return headClone.next == null; 

            return head.next.val == headClone.next.val;
        }
    }
}
