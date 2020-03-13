using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListinBinaryTree
{
    public class Solution
    {
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            int[] pattern = CreatePattern(head);
            int[] pi = Compute_Prefix_Function(pattern);
            int q = 0;
            return IsSubPath(root, pattern, pi, q);
        }

        public bool IsSubPath(TreeNode root , int[] pattern , int[] pi , int q)
        {
            if (root == null)
                return false;
            
            while (q > 0 && pattern[q] != root.val)
            {
                q = pi[q - 1]; 
            }

            if (pattern[q] == root.val)
            {
                q++;
            }

            if (q == pattern.Length)
            {
                return true;
            }
            else
            {
                if (IsSubPath(root.left, pattern, pi, q))
                    return true;
                if (IsSubPath(root.right, pattern, pi, q))
                    return true;
            }

            return false;
        }

        static public int[] Compute_Prefix_Function(int [] pattern)
        {
            int[] pi = new int[pattern.Length];
            int k = 0;
            pi[0] = 0; 
            for (int q = 2; q <= pattern.Length; q++)
            {
                while (k > 0 && pattern[k] != pattern[q - 1])
                {
                    k = pi[k - 1];
                }

                if (pattern[k] == pattern[q - 1])
                {
                    k++;
                }

                pi[q - 1] = k; 
            }

            return pi;
        }

        private int[] CreatePattern(ListNode head)
        {
            LinkedList<int> result = new LinkedList<int>();
            while ( head != null)
            {
                result.AddLast(head.val);
                head = head.next;
            }

            return result.ToArray();
        }
    }
}
