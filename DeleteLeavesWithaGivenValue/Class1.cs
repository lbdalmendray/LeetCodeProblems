using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteLeavesWithaGivenValue
{
    /**
  * Definition for a binary tree node.
  * public class TreeNode {
  *     public int val;
  *     public TreeNode left;
  *     public TreeNode right;
  *     public TreeNode(int x) { val = x; }
  * }
  */
    public class Solution
    {
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            DFS(root,null, target);

            if (root.left == null && root.right == null && root.val == target)
            {
                return null;
            }
            return root;
        }

        private void DFS(TreeNode node, TreeNode Father, int target)
        {
            if (node == null)
                return;

            DFS(node.left,node,target);
            DFS(node.right,node, target);

            if (node.left == null && node.right == null && node.val == target)
            {
                if ( Father != null  )
                {
                    if (Father.left == node)
                    {
                        Father.left = null;
                    }
                    else
                        Father.right = null;
                }
            }
        }
    }


    
  // Definition for a binary tree node.
  public class TreeNode {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
   }
  
}
