using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceaBinarySearchTree
{
    public class Solution
    {
        public TreeNode BalanceBST(TreeNode root)
        {
            var values = new LinkedList<int>();
            DFS(root, values);
            var array = values.ToArray();
            Array.Sort(array);
            return BalanceBST(array, 0, array.Length - 1);
        }

        private TreeNode BalanceBST(int[] array, int index1, int index2)
        {
            if (index1 > index2)
                return null;
            int mid = (index2 + index1) / 2;
            TreeNode result = new TreeNode(array[mid]);
            result.left = BalanceBST(array, index1, mid - 1);
            result.right = BalanceBST(array, mid + 1, index2);
            return result;
        }

        private void DFS(TreeNode root, LinkedList<int> values)
        {
            if (root == null)
                return;
            values.AddLast(root.val);
            DFS(root.left, values);
            DFS(root.right, values);
        }
    }
}
