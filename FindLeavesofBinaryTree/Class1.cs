using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLeavesofBinaryTree
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
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            var leaves = BFS(root);

            LinkedList<IList<int>> result = new LinkedList<IList<int>>();
            while(leaves .Count != 0)
            {
                result.AddLast(leaves.Select(e => e.val).ToList() as IList<int>);
                LinkedList<TreeNodeFather> newLeaves = new LinkedList<TreeNodeFather>();
                foreach (var item in leaves)
                {
                    if (item.Father != null)
                    {
                        if (item.Father.left == item)
                            item.Father.left = null;
                        else
                            item.Father.right = null;

                        if (item.Father.left == null && item.Father.right == null)
                        {
                            newLeaves.AddLast(item.Father);
                        }
                    }
                }

                leaves = newLeaves;
            }

            return result.ToList();
        }

        private LinkedList<TreeNodeFather> BFS(TreeNode root)
        {
            LinkedList<(TreeNodeFather,TreeNode)> queue = new LinkedList<(TreeNodeFather,TreeNode)>();
            TreeNodeFather rootFather = new TreeNodeFather(root, null, false);
            LinkedList<TreeNodeFather> result = new LinkedList<TreeNodeFather>();
            queue.AddLast((rootFather,root));

            while (queue.Count != 0)
            {
                (var nodeFather, var node) = queue.First.Value;
                queue.RemoveFirst();

                bool isLeave = true;
                if (node.left != null)
                {
                    nodeFather.left = new TreeNodeFather(node.left, nodeFather, true);
                    queue.AddLast((nodeFather.left as TreeNodeFather, node.left));
                    isLeave = false;
                }

                if (node.right != null)
                {
                    nodeFather.right = new TreeNodeFather(node.right, nodeFather, false);
                    queue.AddLast((nodeFather.right as TreeNodeFather, node.right));
                    isLeave = false;
                }

                if (isLeave)
                {
                    result.AddLast(nodeFather);
                }
            }
            return result;
        }
    }

    internal class TreeNodeFather : TreeNode
    {
        public TreeNodeFather Father { get; internal set; }

        public TreeNodeFather(TreeNode node , TreeNodeFather father , bool isLeftChild)
            : base(node.val)
        {
            Father = father;
            if (father != null)
            {
                if (isLeftChild)
                    father.left = node;
                else
                    father.right = node;
            }
        }
    }
}
