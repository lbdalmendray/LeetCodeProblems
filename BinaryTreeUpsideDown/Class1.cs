using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeUpsideDown
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
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            if (root == null)
                return null;

            LinkedList<(TreeNode, TreeNode)> list = new LinkedList<(TreeNode, TreeNode)>();
            var node = root;
            TreeNode nodeSecond = null;
            while(node != null)
            {
                list.AddFirst((CloneNode(node), CloneNodeRecursive(nodeSecond)));
                nodeSecond = node.right;
                node = node.left;
            }

            var result = list.First.Value.Item1;
            result.left = list.First.Value.Item2;
            var father = result;
            foreach ((var cNode , var leftNode) in list.Skip(1))
            {
                father.right = cNode;
                cNode.left = leftNode;
                father = cNode;
            }

            return result;
        }

        private TreeNode CloneNode(TreeNode node)
        {
            if (node == null)
                return null;
            return new TreeNode(node.val);
        }

        private TreeNode CloneNodeRecursive(TreeNode node)
        {
            if (node == null)
                return null;
            var result = new TreeNode(node.val);

            var resultLeft = CloneNodeRecursive(node.left);
            var resultRight = CloneNodeRecursive(node.right);
            result.left = resultLeft;
            result.right = resultRight;

            return result;
        }
    }
}
