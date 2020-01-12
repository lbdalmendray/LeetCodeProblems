using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            var currentNode = result;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                var v1 = l1 == null ? 0 : l1.val;
                var v2 = l2 == null ? 0 : l2.val;

                var sum = v1 + v2 + carry;
                currentNode.next = new ListNode(sum % 10);
                carry = sum > 9 ? 1 : 0;
                currentNode = currentNode.next;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }

            if (carry == 1)
                currentNode.next = new ListNode(1);

            return result.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
