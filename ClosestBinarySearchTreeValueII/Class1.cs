using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestBinarySearchTreeValueII
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
        /// <summary>
        /// O( log(n) + k ) 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="target"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> ClosestKValues(TreeNode root, double target, int k)
        {
            Dictionary<TreeNode, TreeNode> fathers = new Dictionary<TreeNode, TreeNode>();
            TreeNode closestNode = GetClosestNode(root,null, target, fathers);
            LinkedList<TreeNode> result = new LinkedList<TreeNode>();
            result.AddLast(closestNode);
            var nextNode = GetNextNode(closestNode, fathers);
            double nextDistance = Distance(nextNode, target);
            var prevNode = GetPreviousNode(closestNode, fathers);
            double prevDistance = Distance(prevNode, target);

            for (int i = 1; i < k; i++)
            {
                if ( nextDistance < prevDistance)
                {
                    result.AddLast(nextNode);
                    nextNode = GetNextNode(nextNode, fathers);
                    nextDistance = Distance(nextNode, target);
                }
                else
                {
                    result.AddFirst(prevNode);
                    prevNode = GetPreviousNode(prevNode, fathers);
                    prevDistance = Distance(prevNode, target);
                }
            }

            return result.Select(n=>n.val).ToList();
        }

        private TreeNode GetPreviousNode(TreeNode node, Dictionary<TreeNode, TreeNode> fathers)
        {
            if (node == null)
                return null;

            if (node.left != null)
            {
                TreeNode result = GetMax(node.left, node, fathers);
                return result;
            }
            else
            {
                while (true)
                {
                    var father = fathers[node];
                    if (father == null)
                        return null;
                    else if (father.left == node)
                        node = father;
                    else
                        return father;
                }
            }
        }

        

        private TreeNode GetNextNode(TreeNode node, Dictionary<TreeNode, TreeNode> fathers)
        {
            if (node == null)
                return null;

            if ( node.right != null)
            {
                TreeNode result = GetMin(node.right, node, fathers);
                return result;
            }
            else
            {
                while(true)
                {
                    var father = fathers[node];
                    if (father == null)
                        return null;
                    else if (father.right == node)
                        node = father;
                    else
                        return father;
                }
            }
        }

        private TreeNode GetMax(TreeNode node, TreeNode father, Dictionary<TreeNode, TreeNode> fathers)
        {
            while (node.right != null)
            {
                if (!fathers.ContainsKey(node))
                    fathers.Add(node, father);

                father = node;
                node = node.right;
            }

            if (!fathers.ContainsKey(node))
                fathers.Add(node, father);

            return node;
        }

        private TreeNode GetMin(TreeNode node, TreeNode father, Dictionary<TreeNode, TreeNode> fathers)
        {
            while (node.left != null)
            {
                if (!fathers.ContainsKey(node))
                    fathers.Add(node, father);

                father = node;
                node = node.left;
            }

            if (!fathers.ContainsKey(node))
                fathers.Add(node, father);

            return node;
        }

        private TreeNode GetClosestNode(TreeNode node, TreeNode father, double target, Dictionary<TreeNode, TreeNode> fathers)
        {
            TreeNode result = null;
            var resDistance = double.PositiveInfinity;            

            while (true)
            {
                fathers.Add(node, father);
                var distance = Distance(node, target);
                if (distance < resDistance)
                {
                    result = node;
                    resDistance = distance;
                }

                if (node.val == target)
                    return node;
                else if (target < node.val)
                {
                    if (node.left == null)
                        break;
                    father = node;
                    node = node.left;
                }
                else
                {
                    if (node.right == null)
                        break;
                    father = node;
                    node = node.right;
                }
            }

            return result;
        }

        private TreeNode GetClosestNode1(TreeNode node, TreeNode father, double target, Dictionary<TreeNode, TreeNode> fathers)
        {
            if (node == null)
                return null;
            fathers.Add(node, father);
            TreeNode child;

            if (node.val == target)
                return node;
            else if (target < node.val)
            {
                child = GetClosestNode1(node.left, node, target, fathers);
            }
            else
            {
                child = GetClosestNode1(node.right, node, target, fathers);
            }

            if (Distance(node, target) < Distance(child, target))
                return node;
            else
                return child;
        }

        private double Distance(TreeNode node , double target)
        {
            if (node == null)
                return double.PositiveInfinity;

            return Math.Abs(node.val - target);
        }
    }
}
