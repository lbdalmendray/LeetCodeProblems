namespace ReverseNodesinKGroup
{
    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
                return head;

            ListNode result = head;
            for (int i = 0; i < k - 1; i++)
                result = result.next;


            int nodeRestCounter = 0;
            ListNode nodeCounter = result.next;
            while (nodeCounter != null)
            {
                nodeCounter = nodeCounter.next;
                nodeRestCounter ++;
            }

            var count = 1 + nodeRestCounter / k; 

            ///////

            ListNode currentNode = head;
            ListNode lastPrevGroupNode = null;

            for (int i = 0; i < count; i++)
            {
                ListNode prevNode = null;
                ListNode firstNode = currentNode;

                for (int j = 1; j <= k; j++)
                {
                    var next = currentNode.next;
                    if (j > 1)
                        currentNode.next = prevNode;
                    else
                        currentNode.next = null;
                    if (j == k)
                    {
                        if (lastPrevGroupNode != null)
                            lastPrevGroupNode.next = currentNode;
                        lastPrevGroupNode = firstNode;
                    }
                    else
                    {
                        prevNode = currentNode;
                    }

                    currentNode = next;
                }
            }

            if ( currentNode != null)
            {
                lastPrevGroupNode.next = currentNode;
            }

            ///////

            return result;
        }
    }
}
